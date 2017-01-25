namespace _2017_01_25_RoboWFApp
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
            this.btOlhoEsquerdo = new System.Windows.Forms.Button();
            this.btOlhoDireito = new System.Windows.Forms.Button();
            this.btNariz = new System.Windows.Forms.Button();
            this.btBoca = new System.Windows.Forms.Button();
            this.btDesconfiado = new System.Windows.Forms.Button();
            this.btTriste = new System.Windows.Forms.Button();
            this.btFeliz = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btOlhoEsquerdo
            // 
            this.btOlhoEsquerdo.Font = new System.Drawing.Font("Microsoft Sans Serif", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOlhoEsquerdo.Location = new System.Drawing.Point(30, 67);
            this.btOlhoEsquerdo.Name = "btOlhoEsquerdo";
            this.btOlhoEsquerdo.Size = new System.Drawing.Size(105, 64);
            this.btOlhoEsquerdo.TabIndex = 0;
            this.btOlhoEsquerdo.Text = "O";
            this.btOlhoEsquerdo.UseVisualStyleBackColor = true;
            // 
            // btOlhoDireito
            // 
            this.btOlhoDireito.Font = new System.Drawing.Font("Microsoft Sans Serif", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOlhoDireito.Location = new System.Drawing.Point(254, 67);
            this.btOlhoDireito.Name = "btOlhoDireito";
            this.btOlhoDireito.Size = new System.Drawing.Size(103, 64);
            this.btOlhoDireito.TabIndex = 1;
            this.btOlhoDireito.Text = "O";
            this.btOlhoDireito.UseVisualStyleBackColor = true;
            // 
            // btNariz
            // 
            this.btNariz.Location = new System.Drawing.Point(178, 150);
            this.btNariz.Name = "btNariz";
            this.btNariz.Size = new System.Drawing.Size(37, 23);
            this.btNariz.TabIndex = 2;
            this.btNariz.UseVisualStyleBackColor = true;
            // 
            // btBoca
            // 
            this.btBoca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBoca.Location = new System.Drawing.Point(117, 215);
            this.btBoca.Name = "btBoca";
            this.btBoca.Size = new System.Drawing.Size(158, 45);
            this.btBoca.TabIndex = 3;
            this.btBoca.Text = "(_____________)";
            this.btBoca.UseVisualStyleBackColor = true;
            // 
            // btDesconfiado
            // 
            this.btDesconfiado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDesconfiado.Location = new System.Drawing.Point(270, 294);
            this.btDesconfiado.Name = "btDesconfiado";
            this.btDesconfiado.Size = new System.Drawing.Size(94, 38);
            this.btDesconfiado.TabIndex = 4;
            this.btDesconfiado.Text = "Desconfiado";
            this.btDesconfiado.UseVisualStyleBackColor = true;
            this.btDesconfiado.Click += new System.EventHandler(this.btDesconfiado_Click);
            // 
            // btTriste
            // 
            this.btTriste.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTriste.Location = new System.Drawing.Point(149, 294);
            this.btTriste.Name = "btTriste";
            this.btTriste.Size = new System.Drawing.Size(94, 38);
            this.btTriste.TabIndex = 7;
            this.btTriste.Text = "Triste";
            this.btTriste.UseVisualStyleBackColor = true;
            this.btTriste.Click += new System.EventHandler(this.btTriste_Click);
            // 
            // btFeliz
            // 
            this.btFeliz.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFeliz.Location = new System.Drawing.Point(24, 294);
            this.btFeliz.Name = "btFeliz";
            this.btFeliz.Size = new System.Drawing.Size(94, 38);
            this.btFeliz.TabIndex = 8;
            this.btFeliz.Text = "Feliz";
            this.btFeliz.UseVisualStyleBackColor = true;
            this.btFeliz.Click += new System.EventHandler(this.btFeliz_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 353);
            this.Controls.Add(this.btFeliz);
            this.Controls.Add(this.btTriste);
            this.Controls.Add(this.btDesconfiado);
            this.Controls.Add(this.btBoca);
            this.Controls.Add(this.btNariz);
            this.Controls.Add(this.btOlhoDireito);
            this.Controls.Add(this.btOlhoEsquerdo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btOlhoEsquerdo;
        private System.Windows.Forms.Button btOlhoDireito;
        private System.Windows.Forms.Button btNariz;
        private System.Windows.Forms.Button btBoca;
        private System.Windows.Forms.Button btDesconfiado;
        private System.Windows.Forms.Button btTriste;
        private System.Windows.Forms.Button btFeliz;
    }
}

