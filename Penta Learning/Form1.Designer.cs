namespace Penta_Learning
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pbxPartitura = new System.Windows.Forms.PictureBox();
            this.ofdBuscarImagen = new System.Windows.Forms.OpenFileDialog();
            this.btnBuscarImagen = new System.Windows.Forms.Button();
            this.btnClasificar = new System.Windows.Forms.Button();
            this.flpClasificacion = new System.Windows.Forms.FlowLayoutPanel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.flpGeneric = new System.Windows.Forms.FlowLayoutPanel();
            this.pbxPicture = new System.Windows.Forms.PictureBox();
            this.lblClasification = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslState = new System.Windows.Forms.ToolStripStatusLabel();
            this.tt1 = new System.Windows.Forms.ToolTip(this.components);
            this.tspb = new System.Windows.Forms.ToolStripProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPartitura)).BeginInit();
            this.flpGeneric.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPicture)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxPartitura
            // 
            this.pbxPartitura.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pbxPartitura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxPartitura.Location = new System.Drawing.Point(43, 73);
            this.pbxPartitura.Name = "pbxPartitura";
            this.pbxPartitura.Size = new System.Drawing.Size(800, 400);
            this.pbxPartitura.TabIndex = 0;
            this.pbxPartitura.TabStop = false;
            this.pbxPartitura.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbxPartitureMouseClick);
            this.pbxPartitura.MouseHover += new System.EventHandler(this.pbxPartitura_MouseHover);
            this.pbxPartitura.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbxPartitura_MouseMove);
            // 
            // ofdBuscarImagen
            // 
            this.ofdBuscarImagen.FileName = "ofdBuscarImagen";
            // 
            // btnBuscarImagen
            // 
            this.btnBuscarImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarImagen.Location = new System.Drawing.Point(363, 15);
            this.btnBuscarImagen.Name = "btnBuscarImagen";
            this.btnBuscarImagen.Size = new System.Drawing.Size(168, 31);
            this.btnBuscarImagen.TabIndex = 1;
            this.btnBuscarImagen.Text = "Buscar Imagen";
            this.btnBuscarImagen.UseVisualStyleBackColor = true;
            this.btnBuscarImagen.Click += new System.EventHandler(this.btnBuscarImagen_Click);
            this.btnBuscarImagen.MouseHover += new System.EventHandler(this.btnBuscarImagen_MouseHover);
            // 
            // btnClasificar
            // 
            this.btnClasificar.Enabled = false;
            this.btnClasificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClasificar.Location = new System.Drawing.Point(363, 487);
            this.btnClasificar.Name = "btnClasificar";
            this.btnClasificar.Size = new System.Drawing.Size(168, 30);
            this.btnClasificar.TabIndex = 2;
            this.btnClasificar.Text = "Ver Clasificación";
            this.btnClasificar.UseVisualStyleBackColor = true;
            this.btnClasificar.Click += new System.EventHandler(this.btnClasificar_Click);
            // 
            // flpClasificacion
            // 
            this.flpClasificacion.AutoScroll = true;
            this.flpClasificacion.Location = new System.Drawing.Point(43, 73);
            this.flpClasificacion.Name = "flpClasificacion";
            this.flpClasificacion.Size = new System.Drawing.Size(800, 400);
            this.flpClasificacion.TabIndex = 3;
            this.flpClasificacion.Visible = false;
            this.flpClasificacion.MouseHover += new System.EventHandler(this.flpClasificacion_MouseHover);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Falling Blocks Logo 2.png");
            this.imageList1.Images.SetKeyName(1, "Falling Blocks Logo 3.png");
            this.imageList1.Images.SetKeyName(2, "Falling Blocks Logo 4.png");
            this.imageList1.Images.SetKeyName(3, "Falling Blocks Logo 5.png");
            this.imageList1.Images.SetKeyName(4, "Falling Blocks Logo1.png");
            this.imageList1.Images.SetKeyName(5, "LaTizaWall2.png");
            this.imageList1.Images.SetKeyName(6, "LatizaWall.png");
            // 
            // flpGeneric
            // 
            this.flpGeneric.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpGeneric.Controls.Add(this.pbxPicture);
            this.flpGeneric.Controls.Add(this.lblClasification);
            this.flpGeneric.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpGeneric.Location = new System.Drawing.Point(55, 12);
            this.flpGeneric.Name = "flpGeneric";
            this.flpGeneric.Size = new System.Drawing.Size(175, 157);
            this.flpGeneric.TabIndex = 0;
            this.flpGeneric.Visible = false;
            // 
            // pbxPicture
            // 
            this.pbxPicture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxPicture.BackgroundImage")));
            this.pbxPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxPicture.Location = new System.Drawing.Point(3, 3);
            this.pbxPicture.Name = "pbxPicture";
            this.pbxPicture.Size = new System.Drawing.Size(172, 92);
            this.pbxPicture.TabIndex = 0;
            this.pbxPicture.TabStop = false;
            // 
            // lblClasification
            // 
            this.lblClasification.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClasification.Location = new System.Drawing.Point(5, 98);
            this.lblClasification.Margin = new System.Windows.Forms.Padding(5, 0, 3, 0);
            this.lblClasification.Name = "lblClasification";
            this.lblClasification.Size = new System.Drawing.Size(170, 32);
            this.lblClasification.TabIndex = 1;
            this.lblClasification.Text = "classification";
            this.lblClasification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslState,
            this.tspb});
            this.statusStrip1.Location = new System.Drawing.Point(0, 531);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(883, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslState
            // 
            this.tslState.Name = "tslState";
            this.tslState.Size = new System.Drawing.Size(174, 17);
            this.tslState.Text = "Esperando por cargar la imagen";
            // 
            // tspb
            // 
            this.tspb.Name = "tspb";
            this.tspb.Size = new System.Drawing.Size(100, 16);
            this.tspb.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 553);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.flpGeneric);
            this.Controls.Add(this.btnClasificar);
            this.Controls.Add(this.btnBuscarImagen);
            this.Controls.Add(this.flpClasificacion);
            this.Controls.Add(this.pbxPartitura);
            this.Name = "Form1";
            this.Text = "PentaLearning";
            this.CursorChanged += new System.EventHandler(this.Form1_CursorChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPartitura)).EndInit();
            this.flpGeneric.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPicture)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxPartitura;
        private System.Windows.Forms.OpenFileDialog ofdBuscarImagen;
        private System.Windows.Forms.Button btnBuscarImagen;
        private System.Windows.Forms.Button btnClasificar;
        private System.Windows.Forms.FlowLayoutPanel flpClasificacion;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.FlowLayoutPanel flpGeneric;
        private System.Windows.Forms.PictureBox pbxPicture;
        private System.Windows.Forms.Label lblClasification;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslState;
        private System.Windows.Forms.ToolTip tt1;
        private System.Windows.Forms.ToolStripProgressBar tspb;
    }
}

