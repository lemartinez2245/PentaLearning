using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;



namespace Penta_Learning
{
    public partial class Form1 : Form
    {

        #region Private Variables

        private bool clasifying;
        private bool isClasified;
        private Image scoreImage;
        private string scoreImagePath;
        private string scoreImageName;
        private Dictionary<String, String> classiiactionDict;
        private Dictionary<String, Rectangle> notesDict;

        #endregion

        #region Auxiliar Structs
        /// <summary>
        /// Represents an Rectangle with their two coins (top-left and bottom-rigth)
        /// </summary>
        struct Rectangle
        {
            // Los i son los de la esquina superior y los s los de la inferior
            // Esta al reves imbecil ;)
            public int Xs;
            public int Ys;
            public int Xi;
            public int Yi;
        }
        #endregion

        #region Form Initialization
        public Form1()
        {
            int[] a = { 1, 2, 3, 4 };
            InitializeComponent();
            notesDict = new Dictionary<string, Rectangle>();
            classiiactionDict = new Dictionary<string, string>();
        }
        #endregion

        #region Buttoms Clicks
        private void btnBuscarImagen_Click(object sender, EventArgs e)
        {

            if (ofdBuscarImagen.ShowDialog() == DialogResult.OK)
            {
                scoreImagePath = ofdBuscarImagen.FileName;
                string[] fileNameSplit = ofdBuscarImagen.FileName.Split('\\');
                scoreImageName = fileNameSplit[fileNameSplit.Length - 1];
                pbxPartitura.BackgroundImage = Image.FromFile(ofdBuscarImagen.FileName);
                scoreImage = Image.FromFile(ofdBuscarImagen.FileName);
                //CopyImageToLocalDir();
                btnClasificar.Enabled = true;
                btnClasificar.Text = "Clasificar";
                isClasified = false;
                clasifying = false;
                tslState.Text = "Sin clasificar";
                flpClasificacion.Visible = false;
                flpClasificacion.Controls.Clear();

            }
        }



        private void btnClasificar_Click(object sender, EventArgs e)
        {
            // Clasificar
            clasifying = !clasifying;

            if (clasifying)
            {
                notesDict = new Dictionary<string, Rectangle>();
            classiiactionDict = new Dictionary<string, string>();
                flpClasificacion.Visible = true;
                btnClasificar.Text = "Ver Imagen";
                if (!isClasified)
                {
                    tslState.Text = "Clasficando...";
                    Clasify();
                    ShowClassification2();
                    tslState.Text = "Clasificado";
                    flpClasificacion.Visible = true;
                    isClasified = true;
                }

            }

            else
            {
                flpClasificacion.Visible = false;
                pbxPartitura.BackgroundImage = scoreImage;
                btnClasificar.Text = "Ver Clasifcación";
            }


        }
        #endregion

        #region Clasification
        private void Clasify()
        {
            // Infromacion sobre el comienzo del proceso
            tspb.Visible = true;
            tspb.Value = 0;
            tslState.Text = "Segmentando...";
            string arg = "segmentation.py" + " " + scoreImagePath;
            var segmentInfo = new ProcessStartInfo("python", arg);
            segmentInfo.WindowStyle = ProcessWindowStyle.Hidden;

            // Se inicia el proceso se espera porque se termine
            var p = Process.Start(segmentInfo);
            p.WaitForExit();
            tspb.Value = 50;

            ReadSegemetationResult();

            tslState.Text = "Clasificando...";

            string innerList = "[";
            int i = 0;
            foreach (string imageName in notesDict.Keys)
            {
                innerList +='"' + imageName + '"';
                i++;
                if (i < notesDict.Keys.Count)
                    innerList += ",";
            }
            innerList += "]";
            string classificationArg = "predict.py" + " " + innerList;
            var classificationInfo = new ProcessStartInfo("python", classificationArg);
            classificationInfo.WindowStyle = ProcessWindowStyle.Hidden;
            var classificationProcess = Process.Start(classificationInfo);
            classificationProcess.WaitForExit();
            tspb.Value = 100;
            ReadClassificationResult();
            tspb.Visible = false;
            // Aqui va la parte de clasificar
        }


        private void ReadSegemetationResult()
        {
            StreamReader reader = new StreamReader("segments.seg", Encoding.Default);


            while (true)
            {
                string line = reader.ReadLine();
                if (line == null)
                    break;
                Console.WriteLine(line);

                string[] firstSplit = line.Split(':');
                string imageName = firstSplit[0];
                imageName += ".png";
                string rest = firstSplit[1];
                rest = rest.Trim();
                string[] secondSplit = rest.Split();
                string xx = secondSplit[0];
                string yy = secondSplit[1];
                string[] xArray = xx.Split(',');
                string[] yArray = yy.Split(',');
                int yi = int.Parse(xArray[0]);
                int ys = int.Parse(xArray[1]);
                int xi = int.Parse(yArray[0]);
                int xs = int.Parse(yArray[1]);
                Rectangle rect = new Rectangle { Xi = xi, Xs = xs, Yi = yi, Ys = ys };
                notesDict[imageName] = rect;
            }

            reader.Close();
        }

        private void ReadClassificationResult() {

            StreamReader reader = new StreamReader("predictions.pred", Encoding.Default);

            while (true) {
                string line = reader.ReadLine();
                if (line == null)
                    break;
                string[] split = line.Split(':');
                string path = split[0];
                string[] split2 = path.Split('\\');
                string imageName = split2[split2.Length - 1];
                string classification = split[1];
                classiiactionDict[imageName] = classification;
                
            }

            reader.Close();
        }


        private void CopyImageToLocalDir()
        {
            StreamReader reader = new StreamReader(scoreImagePath, true);
            StreamWriter writer = new StreamWriter(scoreImageName, false, reader.CurrentEncoding);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                writer.WriteLine(line);
            }
            reader.Close();
            writer.Close();
        }
        #endregion


        #region Show Clasification
        private void ShowClassification()
        {
            var pbx = pbxPicture;
            var lbl = lblClasification;

            foreach (Image image in imageList1.Images)
            {
                var flp = new FlowLayoutPanel
                {
                    Height = flpGeneric.Height,
                    Width = flpGeneric.Width,
                    FlowDirection = flpGeneric.FlowDirection,
                    Anchor = flpGeneric.Anchor,
                    AutoSize = flpGeneric.AutoSize,
                };

                flp.Controls.Add(new PictureBox
                {
                    Width = pbx.Width,
                    Height = pbx.Height,
                    BackgroundImageLayout = pbx.BackgroundImageLayout,
                    BackgroundImage = image,
                });

                flp.Controls.Add(new Label
                {
                    Width = lbl.Width,
                    Height = lbl.Height,
                    Font = lbl.Font,
                    TextAlign = lbl.TextAlign,
                    Text = "Clasification"
                });

                flpClasificacion.Controls.Add(flp);
            }


        }

        private void ShowClassification2()
        {

            foreach (string imageName in notesDict.Keys)
            {
                string realName = imageName;
                Image image = Image.FromFile(realName);
                var flp = new FlowLayoutPanel
                {
                    Width = 150,
                    Height = 150,
                    FlowDirection = FlowDirection.TopDown,
                    AutoSize = false,

                };
                var pbx = new PictureBox
                {
                    BackgroundImage = image,
                    BackgroundImageLayout = ImageLayout.Stretch,
                    Width = 100,
                    Height = 100,
                };

                var lbl = new Label
                {
                    Width = lblClasification.Width,
                    Height = lblClasification.Height,
                    Font = lblClasification.Font,
                    Size = lblClasification.Size,
                    TextAlign = ContentAlignment.TopLeft,
                    Text = classiiactionDict[imageName]
                };

                flp.Controls.Add(pbx);
                flp.Controls.Add(lbl);
                flpClasificacion.Controls.Add(flp);
            }
        }

        #endregion

        #region Mouse Overs

        #endregion


        private void Form1_CursorChanged(object sender, EventArgs e)
        {

        }

        private void flpClasificacion_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void flpClasificacion_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnBuscarImagen_MouseHover(object sender, EventArgs e)
        {

        }

        private void pbxPartitura_MouseHover(object sender, EventArgs e)
        {


        }

        private void pbxPartitura_MouseMove(object sender, MouseEventArgs e)
        {



        }

        private void pbxPartitureMouseClick(object sender, MouseEventArgs e)
        {
            var x = e.X;
            var y = e.Y;

            foreach (var imageName in notesDict.Keys)
            {
                var rectangle = notesDict[imageName];
                var classification = classiiactionDict[imageName]; 
                var xs = rectangle.Xs;
                var ys = rectangle.Ys;
                var xi = rectangle.Xi;
                var yi = rectangle.Yi;

                if (x > xi && x < xs && y > yi && y < ys)
                {
                    tt1.Show(classification, sender as PictureBox);

                }
            }
        }
    }
}
