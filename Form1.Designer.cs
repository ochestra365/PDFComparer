
namespace PDFComparer
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.TplMain = new System.Windows.Forms.TableLayoutPanel();
            this.TplOrinal = new System.Windows.Forms.TableLayoutPanel();
            this.TplTarget = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PicPDF1 = new System.Windows.Forms.PictureBox();
            this.PicPDF2 = new System.Windows.Forms.PictureBox();
            this.txtPDF1 = new System.Windows.Forms.TextBox();
            this.txtPDF2 = new System.Windows.Forms.TextBox();
            this.TplMain.SuspendLayout();
            this.TplOrinal.SuspendLayout();
            this.TplTarget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPDF1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicPDF2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(1235, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 592);
            this.button1.TabIndex = 0;
            this.button1.Text = "Convert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TplMain
            // 
            this.TplMain.ColumnCount = 3;
            this.TplMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.TplMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.TplMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TplMain.Controls.Add(this.button1, 2, 0);
            this.TplMain.Controls.Add(this.TplTarget, 1, 0);
            this.TplMain.Controls.Add(this.TplOrinal, 0, 0);
            this.TplMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TplMain.Location = new System.Drawing.Point(0, 0);
            this.TplMain.Name = "TplMain";
            this.TplMain.RowCount = 1;
            this.TplMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TplMain.Size = new System.Drawing.Size(1371, 598);
            this.TplMain.TabIndex = 1;
            // 
            // TplOrinal
            // 
            this.TplOrinal.ColumnCount = 1;
            this.TplOrinal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TplOrinal.Controls.Add(this.label1, 0, 0);
            this.TplOrinal.Controls.Add(this.PicPDF1, 0, 1);
            this.TplOrinal.Controls.Add(this.txtPDF1, 0, 2);
            this.TplOrinal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TplOrinal.Location = new System.Drawing.Point(3, 3);
            this.TplOrinal.Name = "TplOrinal";
            this.TplOrinal.RowCount = 3;
            this.TplOrinal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TplOrinal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.TplOrinal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TplOrinal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TplOrinal.Size = new System.Drawing.Size(610, 592);
            this.TplOrinal.TabIndex = 0;
            // 
            // TplTarget
            // 
            this.TplTarget.ColumnCount = 1;
            this.TplTarget.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TplTarget.Controls.Add(this.label2, 0, 0);
            this.TplTarget.Controls.Add(this.PicPDF2, 0, 1);
            this.TplTarget.Controls.Add(this.txtPDF2, 0, 2);
            this.TplTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TplTarget.Location = new System.Drawing.Point(619, 3);
            this.TplTarget.Name = "TplTarget";
            this.TplTarget.RowCount = 3;
            this.TplTarget.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TplTarget.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.TplTarget.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TplTarget.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TplTarget.Size = new System.Drawing.Size(610, 592);
            this.TplTarget.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("굴림", 50F);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(604, 118);
            this.label1.TabIndex = 0;
            this.label1.Text = "PDF1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("굴림", 50F);
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(604, 118);
            this.label2.TabIndex = 1;
            this.label2.Text = "PDF2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PicPDF1
            // 
            this.PicPDF1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicPDF1.Location = new System.Drawing.Point(3, 121);
            this.PicPDF1.Name = "PicPDF1";
            this.PicPDF1.Size = new System.Drawing.Size(604, 408);
            this.PicPDF1.TabIndex = 1;
            this.PicPDF1.TabStop = false;
            // 
            // PicPDF2
            // 
            this.PicPDF2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicPDF2.Location = new System.Drawing.Point(3, 121);
            this.PicPDF2.Name = "PicPDF2";
            this.PicPDF2.Size = new System.Drawing.Size(604, 408);
            this.PicPDF2.TabIndex = 1;
            this.PicPDF2.TabStop = false;
            // 
            // txtPDF1
            // 
            this.txtPDF1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPDF1.Font = new System.Drawing.Font("굴림", 50F);
            this.txtPDF1.Location = new System.Drawing.Point(3, 535);
            this.txtPDF1.Multiline = true;
            this.txtPDF1.Name = "txtPDF1";
            this.txtPDF1.Size = new System.Drawing.Size(604, 54);
            this.txtPDF1.TabIndex = 2;
            this.txtPDF1.Text = "1";
            this.txtPDF1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPDF2
            // 
            this.txtPDF2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPDF2.Font = new System.Drawing.Font("굴림", 50F);
            this.txtPDF2.Location = new System.Drawing.Point(3, 535);
            this.txtPDF2.Multiline = true;
            this.txtPDF2.Name = "txtPDF2";
            this.txtPDF2.Size = new System.Drawing.Size(604, 54);
            this.txtPDF2.TabIndex = 2;
            this.txtPDF2.Text = "1";
            this.txtPDF2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 598);
            this.Controls.Add(this.TplMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TplMain.ResumeLayout(false);
            this.TplOrinal.ResumeLayout(false);
            this.TplOrinal.PerformLayout();
            this.TplTarget.ResumeLayout(false);
            this.TplTarget.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPDF1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicPDF2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel TplMain;
        private System.Windows.Forms.TableLayoutPanel TplTarget;
        private System.Windows.Forms.TableLayoutPanel TplOrinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PicPDF2;
        private System.Windows.Forms.PictureBox PicPDF1;
        private System.Windows.Forms.TextBox txtPDF1;
        private System.Windows.Forms.TextBox txtPDF2;
    }
}

