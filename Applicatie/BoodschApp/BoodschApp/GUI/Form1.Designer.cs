﻿namespace BoodschApp
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
            this.lbBoodschappen = new System.Windows.Forms.ListBox();
            this.lbProducten = new System.Windows.Forms.ListBox();
            this.lbGerechten = new System.Windows.Forms.ListBox();
            this.btnProductBeheer = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbWinkels = new System.Windows.Forms.ComboBox();
            this.btnSorteerZuinig = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnLooproute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbBoodschappen
            // 
            this.lbBoodschappen.FormattingEnabled = true;
            this.lbBoodschappen.Location = new System.Drawing.Point(12, 76);
            this.lbBoodschappen.Name = "lbBoodschappen";
            this.lbBoodschappen.Size = new System.Drawing.Size(164, 225);
            this.lbBoodschappen.TabIndex = 0;
            // 
            // lbProducten
            // 
            this.lbProducten.FormattingEnabled = true;
            this.lbProducten.Location = new System.Drawing.Point(200, 76);
            this.lbProducten.Name = "lbProducten";
            this.lbProducten.Size = new System.Drawing.Size(174, 225);
            this.lbProducten.TabIndex = 1;
            // 
            // lbGerechten
            // 
            this.lbGerechten.FormattingEnabled = true;
            this.lbGerechten.Location = new System.Drawing.Point(396, 76);
            this.lbGerechten.Name = "lbGerechten";
            this.lbGerechten.Size = new System.Drawing.Size(182, 225);
            this.lbGerechten.TabIndex = 2;
            this.lbGerechten.SelectedIndexChanged += new System.EventHandler(this.lbGerechten_SelectedIndexChanged);
            // 
            // btnProductBeheer
            // 
            this.btnProductBeheer.Location = new System.Drawing.Point(13, 13);
            this.btnProductBeheer.Name = "btnProductBeheer";
            this.btnProductBeheer.Size = new System.Drawing.Size(131, 23);
            this.btnProductBeheer.TabIndex = 3;
            this.btnProductBeheer.Text = "Producten Beheren";
            this.btnProductBeheer.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Gerechten Beheren";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(287, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Winkels Beheren";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cbWinkels
            // 
            this.cbWinkels.FormattingEnabled = true;
            this.cbWinkels.Location = new System.Drawing.Point(12, 307);
            this.cbWinkels.Name = "cbWinkels";
            this.cbWinkels.Size = new System.Drawing.Size(164, 21);
            this.cbWinkels.TabIndex = 6;
            // 
            // btnSorteerZuinig
            // 
            this.btnSorteerZuinig.Location = new System.Drawing.Point(396, 49);
            this.btnSorteerZuinig.Name = "btnSorteerZuinig";
            this.btnSorteerZuinig.Size = new System.Drawing.Size(182, 23);
            this.btnSorteerZuinig.TabIndex = 7;
            this.btnSorteerZuinig.Text = "Sorteer Gerechten";
            this.btnSorteerZuinig.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 48);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(163, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Exporteer";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnLooproute
            // 
            this.btnLooproute.Location = new System.Drawing.Point(12, 334);
            this.btnLooproute.Name = "btnLooproute";
            this.btnLooproute.Size = new System.Drawing.Size(75, 23);
            this.btnLooproute.TabIndex = 9;
            this.btnLooproute.Text = "Looproute";
            this.btnLooproute.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 359);
            this.Controls.Add(this.btnLooproute);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnSorteerZuinig);
            this.Controls.Add(this.cbWinkels);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnProductBeheer);
            this.Controls.Add(this.lbGerechten);
            this.Controls.Add(this.lbProducten);
            this.Controls.Add(this.lbBoodschappen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbBoodschappen;
        private System.Windows.Forms.ListBox lbProducten;
        private System.Windows.Forms.ListBox lbGerechten;
        private System.Windows.Forms.Button btnProductBeheer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbWinkels;
        private System.Windows.Forms.Button btnSorteerZuinig;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnLooproute;
    }
}

