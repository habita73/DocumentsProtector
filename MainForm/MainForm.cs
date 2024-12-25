using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace DocumentsProtector
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "watermark.png");
            pictureBox1.Image = Image.FromFile(absolutePath);
        }
        string baseDirectory;
        string sourceDirectory;
        string watermarkPath;
        string outputDirectory;

        private void Form1_Load(object sender, EventArgs e)
        {
            baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            sourceDirectory = Path.Combine(baseDirectory, "source_pdfs");
            watermarkPath = Path.Combine(baseDirectory, "watermark.png");
            outputDirectory = Path.Combine(baseDirectory, "optimized_pdfs");

            // Ensure the source and output directories exist
            if (!Directory.Exists(sourceDirectory)) Directory.CreateDirectory(sourceDirectory);

            if (!Directory.Exists(outputDirectory)) Directory.CreateDirectory(outputDirectory);

            // Ensure the watermark file exists
            if (!File.Exists(watermarkPath))
            {
                MessageBox.Show($"Watermark file not found: {watermarkPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        private void ProcessPdf(string pdfPath, string watermarkPath, string outputPath)
        {
            using (PdfDocument inputDocument = PdfReader.Open(pdfPath, PdfDocumentOpenMode.Import))
            using (PdfDocument outputDocument = new PdfDocument())
            {
                XImage watermarkImage = XImage.FromFile(watermarkPath);

                for (int i = 0; i < inputDocument.Pages.Count; i++)
                {
                    PdfPage page = inputDocument.Pages[i];

                    // Convert page to grayscale
                    Image grayscaleImage;

                    if (checkBox1.Checked)
                    {
                        // Convert page to grayscale
                        grayscaleImage = RenderPageToGrayscale(page, pdfPath, i);
                    }
                    else
                    {
                        // Render the page as an image without converting to grayscale
                        grayscaleImage = RenderPageToImage(page, pdfPath, i);
                    }

                    // Convert grayscale image to XImage
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        grayscaleImage.Save(memoryStream, ImageFormat.Png);
                        memoryStream.Position = 0;
                        XImage grayXImage = XImage.FromStream(memoryStream);

                        // Add page to the output document
                        PdfPage newPage = outputDocument.AddPage(page);
                        using (XGraphics gfx = XGraphics.FromPdfPage(newPage))
                        {
                            gfx.DrawImage(grayXImage, 0, 0, newPage.Width, newPage.Height);

                            // Add the watermark
                            AddTransparentWatermark(gfx, watermarkImage, newPage.Width, newPage.Height, watermarkPath);
                        }
                    }
                }

                outputDocument.Save(outputPath);
            }
        }
        private Image RenderPageToImage(PdfPage page, string pdfPath, int pageIndex)
        {
            using (var pdfDocument = PdfiumViewer.PdfDocument.Load(pdfPath))
            {
                // Ensure pageIndex is within range
                if (pageIndex < 0 || pageIndex >= pdfDocument.PageCount)
                    throw new ArgumentOutOfRangeException(nameof(pageIndex), "Invalid page index.");

                // Render the page as an image
                return pdfDocument.Render(pageIndex, (int)page.Width.Point, (int)page.Height.Point, dpiX: 96, dpiY: 96, PdfiumViewer.PdfRenderFlags.Annotations);
            }
        }

        private Image RenderPageToGrayscale(PdfPage page, string pdfPath, int pageIndex)
        {

            using (var pdfDocument = PdfiumViewer.PdfDocument.Load(pdfPath))
            {
                // Ensure pageIndex is within range
                if (pageIndex < 0 || pageIndex >= pdfDocument.PageCount)
                    throw new ArgumentOutOfRangeException(nameof(pageIndex), "Invalid page index.");

                // Render the page as an image
                using (Image renderedImage = pdfDocument.Render(pageIndex, (int)page.Width.Point, (int)page.Height.Point, dpiX: 96, dpiY: 96, PdfiumViewer.PdfRenderFlags.Annotations))
                {
                    // Convert the rendered image to grayscale
                    return ConvertToGrayscale(renderedImage);
                }
            }
        }

        private Image ConvertToGrayscale(Image originalImage)
        {
            Bitmap grayscaleBitmap = new Bitmap(originalImage.Width, originalImage.Height);

            using (Graphics graphics = Graphics.FromImage(grayscaleBitmap))
            {
                ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                {
            new float[] { 0.3f, 0.3f, 0.3f, 0, 0 },
            new float[] { 0.59f, 0.59f, 0.59f, 0, 0 },
            new float[] { 0.11f, 0.11f, 0.11f, 0, 0 },
            new float[] { 0, 0, 0, 1, 0 },
            new float[] { 0, 0, 0, 0, 1 }
                });

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix);

                graphics.DrawImage(originalImage,
                    new Rectangle(0, 0, grayscaleBitmap.Width, grayscaleBitmap.Height),
                    0, 0, originalImage.Width, originalImage.Height,
                    GraphicsUnit.Pixel,
                    attributes);
            }

            return grayscaleBitmap;
        }


        private void AddTransparentWatermark(XGraphics gfx, XImage watermark, double pageWidth, double pageHeight, string watermarkPath)
        {
            // Resize the watermark image to a 1:1 aspect ratio
            double watermarkSize = Math.Min(pageWidth, pageHeight) / (4 - trackBarWatermarkSize.Value);
            double x = 0;
            double y = (pageHeight - watermarkSize) / 2;
            if (radioButtonCentre.Checked == true)
            {
                x = (pageWidth - watermarkSize) / 2;
            }
            else if
                (radioButtonRight.Checked == true) x = pageWidth - watermarkSize;
            // Preprocess watermark to add transparency
            Image transparentWatermark = CreateTransparentWatermark(watermark, (double)trackBar1.Value / 10, watermarkPath);
            // Convert to XImage using a memory stream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                transparentWatermark.Save(memoryStream, ImageFormat.Png);
                memoryStream.Position = 0;
                XImage transparentXImage = XImage.FromStream(memoryStream);

                // Draw the watermark
                gfx.DrawImage(transparentXImage, x, y, watermarkSize, watermarkSize);
            }
        }

        // Helper method to create a transparent watermark
        private Image CreateTransparentWatermark(XImage watermark, double opacity, string watermarkPath)
        {
            // Convert XImage to System.Drawing.Image
            using (Image originalImage = Image.FromFile(watermarkPath))
            {
                Bitmap transparentImage = new Bitmap(originalImage.Width, originalImage.Height);

                using (Graphics graphics = Graphics.FromImage(transparentImage))
                {
                    graphics.Clear(Color.Transparent);

                    // Set transparency using ColorMatrix
                    ColorMatrix colorMatrix = new ColorMatrix
                    {
                        Matrix33 = (float)opacity // Set alpha channel
                    };

                    ImageAttributes attributes = new ImageAttributes();
                    attributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    graphics.DrawImage(originalImage,
                        new Rectangle(0, 0, transparentImage.Width, transparentImage.Height),
                        0, 0, originalImage.Width, originalImage.Height,
                        GraphicsUnit.Pixel,
                        attributes);
                }

                return transparentImage;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int FilesCount = listBoxSourcesFiles.Items.Count;
            foreach (string filePath in listBoxSourcesFiles.Items)
            {
                FilesCount = FilesCount - 1;
                string outputFilePath = Path.Combine(outputDirectory, Path.GetFileName(filePath));
                ProcessPdf(filePath, watermarkPath, outputFilePath);
                Text = $"{(FilesCount * 100 / listBoxSourcesFiles.Items.Count).ToString("  0")}% Processing {Path.GetFileName(filePath)}...";

            }
            MessageBox.Show(Text = "Processing complete.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_AddSourcesFiles_Click(object sender, EventArgs e)
        {
            // add select/open multiple pdf files
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = sourceDirectory,
                Filter = "PDF files (*.pdf)|*.pdf",
                Multiselect = true
            };
            // affect to list of files
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in openFileDialog.FileNames)
                {
                    string fileName = Path.GetFileName(filePath);
                    string destFilePath = Path.Combine(filePath);
                    listBoxSourcesFiles.Items.Add(destFilePath);
                }
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            for (int i = listBoxSourcesFiles.SelectedIndices.Count - 1; i >= 0; i--)
            {
                listBoxSourcesFiles.Items.RemoveAt(listBoxSourcesFiles.SelectedIndices[i]);
            }
        }

        private void btn_ResultFolder_Click(object sender, EventArgs e)
        {
            // open / show outputDirectory in explorer
            System.Diagnostics.Process.Start("explorer.exe", outputDirectory);
        }

        private void btn_watermark_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = baseDirectory,
                Filter = "PNG files (*.png)|*.png",
                Multiselect = false
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string destFilePath = Path.Combine(baseDirectory, "watermark.png");
                pictureBox1.Image.Dispose();
                File.Copy(filePath, destFilePath, true);
                watermarkPath = destFilePath;
                pictureBox1.Image = Image.FromFile(destFilePath);
            }
        }
    }
}
