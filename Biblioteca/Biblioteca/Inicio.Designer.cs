namespace Biblioteca
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.btn_libros = new System.Windows.Forms.Button();
            this.btn_prestamo = new System.Windows.Forms.Button();
            this.btn_lector = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.agregar_editorial = new System.Windows.Forms.Button();
            this.btnautor = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_libros
            // 
            this.btn_libros.BackColor = System.Drawing.Color.Transparent;
            this.btn_libros.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_libros.BackgroundImage")));
            this.btn_libros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_libros.FlatAppearance.BorderSize = 0;
            this.btn_libros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_libros.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_libros.Location = new System.Drawing.Point(147, 104);
            this.btn_libros.Margin = new System.Windows.Forms.Padding(2);
            this.btn_libros.Name = "btn_libros";
            this.btn_libros.Size = new System.Drawing.Size(100, 100);
            this.btn_libros.TabIndex = 1;
            this.btn_libros.UseVisualStyleBackColor = false;
            this.btn_libros.Click += new System.EventHandler(this.btn_libros_Click);
            // 
            // btn_prestamo
            // 
            this.btn_prestamo.BackColor = System.Drawing.Color.Transparent;
            this.btn_prestamo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_prestamo.BackgroundImage")));
            this.btn_prestamo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_prestamo.FlatAppearance.BorderSize = 0;
            this.btn_prestamo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_prestamo.Location = new System.Drawing.Point(147, 222);
            this.btn_prestamo.Margin = new System.Windows.Forms.Padding(2);
            this.btn_prestamo.Name = "btn_prestamo";
            this.btn_prestamo.Size = new System.Drawing.Size(100, 100);
            this.btn_prestamo.TabIndex = 2;
            this.btn_prestamo.UseVisualStyleBackColor = false;
            this.btn_prestamo.Click += new System.EventHandler(this.btn_prestamo_Click);
            // 
            // btn_lector
            // 
            this.btn_lector.BackColor = System.Drawing.Color.Transparent;
            this.btn_lector.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_lector.BackgroundImage")));
            this.btn_lector.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_lector.FlatAppearance.BorderSize = 0;
            this.btn_lector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_lector.Location = new System.Drawing.Point(24, 104);
            this.btn_lector.Margin = new System.Windows.Forms.Padding(2);
            this.btn_lector.Name = "btn_lector";
            this.btn_lector.Size = new System.Drawing.Size(100, 100);
            this.btn_lector.TabIndex = 0;
            this.btn_lector.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_lector.UseVisualStyleBackColor = false;
            this.btn_lector.Click += new System.EventHandler(this.btn_lector_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(134, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.MaximumSize = new System.Drawing.Size(750, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(451, 77);
            this.label1.TabIndex = 10;
            this.label1.Text = "BIBLIOTECA";
            this.label1.ForeColorChanged += new System.EventHandler(this.label1_DpiChangedAfterParent);
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(339, 117);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(272, 312);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // agregar_editorial
            // 
            this.agregar_editorial.BackColor = System.Drawing.Color.Transparent;
            this.agregar_editorial.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("agregar_editorial.BackgroundImage")));
            this.agregar_editorial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.agregar_editorial.FlatAppearance.BorderSize = 0;
            this.agregar_editorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agregar_editorial.Location = new System.Drawing.Point(24, 222);
            this.agregar_editorial.Margin = new System.Windows.Forms.Padding(2);
            this.agregar_editorial.Name = "agregar_editorial";
            this.agregar_editorial.Size = new System.Drawing.Size(100, 100);
            this.agregar_editorial.TabIndex = 12;
            this.agregar_editorial.UseVisualStyleBackColor = false;
            this.agregar_editorial.Click += new System.EventHandler(this.agregar_editorial_Click);
            // 
            // btnautor
            // 
            this.btnautor.BackColor = System.Drawing.Color.Transparent;
            this.btnautor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnautor.BackgroundImage")));
            this.btnautor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnautor.FlatAppearance.BorderSize = 0;
            this.btnautor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnautor.Location = new System.Drawing.Point(92, 339);
            this.btnautor.Margin = new System.Windows.Forms.Padding(2);
            this.btnautor.Name = "btnautor";
            this.btnautor.Size = new System.Drawing.Size(100, 100);
            this.btnautor.TabIndex = 13;
            this.btnautor.UseVisualStyleBackColor = false;
            this.btnautor.Click += new System.EventHandler(this.btneditorial_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Bell MT", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(629, 396);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 14;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(690, 457);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnautor);
            this.Controls.Add(this.agregar_editorial);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_prestamo);
            this.Controls.Add(this.btn_lector);
            this.Controls.Add(this.btn_libros);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Inicio";
            this.Text = "Menú";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_libros;
        private System.Windows.Forms.Button btn_prestamo;
        private System.Windows.Forms.Button btn_lector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button agregar_editorial;
        private System.Windows.Forms.Button btnautor;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
    }
}

