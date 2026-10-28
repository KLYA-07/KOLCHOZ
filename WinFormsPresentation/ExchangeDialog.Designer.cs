namespace WinFormsPresentation
{
    partial class ExchangeDialog
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
            title = new Label();
            payerName = new Label();
            sellerName = new Label();
            switchButton = new Button();
            financialCapital = new Label();
            exchangeSum = new Label();
            exchangeButton = new Button();
            label2 = new Label();
            totalFieldArea = new Label();
            fieldArea = new TextBox();
            fieldCost = new Label();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Segoe UI", 15F);
            title.Location = new Point(226, 7);
            title.Margin = new Padding(2, 0, 2, 0);
            title.Name = "title";
            title.Size = new Size(289, 35);
            title.TabIndex = 0;
            title.Text = "Купля-продажа урожая";
            // 
            // payerName
            // 
            payerName.BorderStyle = BorderStyle.FixedSingle;
            payerName.Location = new Point(10, 75);
            payerName.Margin = new Padding(2, 0, 2, 0);
            payerName.Name = "payerName";
            payerName.Size = new Size(310, 45);
            payerName.TabIndex = 1;
            payerName.Text = "Покупатель: ";
            payerName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // sellerName
            // 
            sellerName.BorderStyle = BorderStyle.FixedSingle;
            sellerName.Location = new Point(398, 76);
            sellerName.Margin = new Padding(2, 0, 2, 0);
            sellerName.Name = "sellerName";
            sellerName.Size = new Size(310, 45);
            sellerName.TabIndex = 2;
            sellerName.Text = "Продавец: ";
            sellerName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // switchButton
            // 
            switchButton.Font = new Font("Segoe UI", 10F);
            switchButton.Location = new Point(324, 76);
            switchButton.Margin = new Padding(2, 2, 2, 2);
            switchButton.Name = "switchButton";
            switchButton.Size = new Size(70, 45);
            switchButton.TabIndex = 3;
            switchButton.Text = "<->";
            switchButton.UseVisualStyleBackColor = true;
            switchButton.Click += switchButton_Click;
            // 
            // financialCapital
            // 
            financialCapital.BorderStyle = BorderStyle.FixedSingle;
            financialCapital.Location = new Point(10, 141);
            financialCapital.Margin = new Padding(2, 0, 2, 0);
            financialCapital.Name = "financialCapital";
            financialCapital.Size = new Size(216, 38);
            financialCapital.TabIndex = 4;
            financialCapital.Text = "Имеющийся капитал:";
            financialCapital.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // exchangeSum
            // 
            exchangeSum.BorderStyle = BorderStyle.FixedSingle;
            exchangeSum.Location = new Point(231, 177);
            exchangeSum.Margin = new Padding(2, 0, 2, 0);
            exchangeSum.Name = "exchangeSum";
            exchangeSum.Size = new Size(268, 45);
            exchangeSum.TabIndex = 8;
            exchangeSum.Text = "Итоговая сумма: ";
            exchangeSum.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // exchangeButton
            // 
            exchangeButton.Location = new Point(294, 238);
            exchangeButton.Margin = new Padding(2, 2, 2, 2);
            exchangeButton.Name = "exchangeButton";
            exchangeButton.Size = new Size(162, 27);
            exchangeButton.TabIndex = 9;
            exchangeButton.Text = "Совершить сделку";
            exchangeButton.UseVisualStyleBackColor = true;
            exchangeButton.Click += exchangeButton_Click;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Location = new Point(10, 178);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(217, 87);
            label2.TabIndex = 11;
            label2.Text = "Площадь земли для покупки:";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // totalFieldArea
            // 
            totalFieldArea.BorderStyle = BorderStyle.FixedSingle;
            totalFieldArea.Location = new Point(506, 141);
            totalFieldArea.Margin = new Padding(2, 0, 2, 0);
            totalFieldArea.Name = "totalFieldArea";
            totalFieldArea.Size = new Size(202, 73);
            totalFieldArea.TabIndex = 12;
            totalFieldArea.Text = "Площадь имеющейся земли:";
            totalFieldArea.TextAlign = ContentAlignment.TopCenter;
            // 
            // fieldArea
            // 
            fieldArea.Location = new Point(51, 225);
            fieldArea.Margin = new Padding(2, 2, 2, 2);
            fieldArea.Name = "fieldArea";
            fieldArea.Size = new Size(135, 27);
            fieldArea.TabIndex = 13;
            fieldArea.Validating += fieldArea_Validating;
            // 
            // fieldCost
            // 
            fieldCost.BorderStyle = BorderStyle.FixedSingle;
            fieldCost.Location = new Point(506, 214);
            fieldCost.Margin = new Padding(2, 0, 2, 0);
            fieldCost.Name = "fieldCost";
            fieldCost.Size = new Size(202, 52);
            fieldCost.TabIndex = 14;
            fieldCost.Text = "Цена за Га:";
            fieldCost.TextAlign = ContentAlignment.TopCenter;
            // 
            // ExchangeDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(718, 325);
            Controls.Add(fieldCost);
            Controls.Add(fieldArea);
            Controls.Add(exchangeButton);
            Controls.Add(exchangeSum);
            Controls.Add(financialCapital);
            Controls.Add(switchButton);
            Controls.Add(sellerName);
            Controls.Add(payerName);
            Controls.Add(title);
            Controls.Add(totalFieldArea);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            Name = "ExchangeDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Рынок урожая";
            Load += ExchangeDialog_Load;
            MouseClick += LeaveEditingOnMouseClick;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title;
        private Label payerName;
        private Label sellerName;
        private Button switchButton;
        private Label financialCapital;
        private Label exchangeSum;
        private Button exchangeButton;
        private Label label2;
        private Label totalFieldArea;
        private TextBox fieldArea;
        private Label fieldCost;
    }
}