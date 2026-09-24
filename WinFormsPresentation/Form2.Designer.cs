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
            allProducts = new ComboBox();
            productCount = new TextBox();
            label1 = new Label();
            exchangeSum = new Label();
            exchangeButton = new Button();
            productCost = new Label();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Segoe UI", 15F);
            title.Location = new Point(282, 9);
            title.Name = "title";
            title.Size = new Size(342, 41);
            title.TabIndex = 0;
            title.Text = "Купля-продажа урожая";
            // 
            // payerName
            // 
            payerName.Location = new Point(12, 87);
            payerName.Name = "payerName";
            payerName.Size = new Size(387, 71);
            payerName.TabIndex = 1;
            payerName.Text = "Покупатель: ";
            payerName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // sellerName
            // 
            sellerName.Location = new Point(498, 87);
            sellerName.Name = "sellerName";
            sellerName.Size = new Size(387, 71);
            sellerName.TabIndex = 2;
            sellerName.Text = "Продавец: ";
            sellerName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // switchButton
            // 
            switchButton.Font = new Font("Segoe UI", 10F);
            switchButton.Location = new Point(405, 102);
            switchButton.Name = "switchButton";
            switchButton.Size = new Size(81, 41);
            switchButton.TabIndex = 3;
            switchButton.Text = "<->";
            switchButton.UseVisualStyleBackColor = true;
            switchButton.Click += switchButton_Click;
            // 
            // financialCapital
            // 
            financialCapital.Location = new Point(64, 169);
            financialCapital.Name = "financialCapital";
            financialCapital.Size = new Size(270, 47);
            financialCapital.TabIndex = 4;
            financialCapital.Text = "Имеющийся капитал: ";
            financialCapital.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // allProducts
            // 
            allProducts.DropDownStyle = ComboBoxStyle.DropDownList;
            allProducts.FormattingEnabled = true;
            allProducts.Location = new Point(598, 177);
            allProducts.Name = "allProducts";
            allProducts.Size = new Size(182, 33);
            allProducts.TabIndex = 5;
            allProducts.SelectedIndexChanged += allProducts_SelectedIndexChanged;
            // 
            // productCount
            // 
            productCount.Location = new Point(375, 177);
            productCount.Name = "productCount";
            productCount.Size = new Size(150, 31);
            productCount.TabIndex = 6;
            productCount.Validating += productCount_Validating;
            // 
            // label1
            // 
            label1.Location = new Point(361, 211);
            label1.Name = "label1";
            label1.Size = new Size(177, 32);
            label1.TabIndex = 7;
            label1.Text = "Количество: ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // exchangeSum
            // 
            exchangeSum.Location = new Point(361, 243);
            exchangeSum.Name = "exchangeSum";
            exchangeSum.Size = new Size(177, 56);
            exchangeSum.TabIndex = 8;
            exchangeSum.Text = "Итоговая сумма: ";
            exchangeSum.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // exchangeButton
            // 
            exchangeButton.Location = new Point(348, 302);
            exchangeButton.Name = "exchangeButton";
            exchangeButton.Size = new Size(202, 34);
            exchangeButton.TabIndex = 9;
            exchangeButton.Text = "Совершить сделку";
            exchangeButton.UseVisualStyleBackColor = true;
            // 
            // productCost
            // 
            productCost.Location = new Point(598, 213);
            productCost.Name = "productCost";
            productCost.Size = new Size(182, 32);
            productCost.TabIndex = 10;
            productCost.Text = "Цена: ";
            productCost.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ExchangeDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(897, 799);
            Controls.Add(productCost);
            Controls.Add(exchangeButton);
            Controls.Add(exchangeSum);
            Controls.Add(label1);
            Controls.Add(productCount);
            Controls.Add(allProducts);
            Controls.Add(financialCapital);
            Controls.Add(switchButton);
            Controls.Add(sellerName);
            Controls.Add(payerName);
            Controls.Add(title);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ExchangeDialog";
            Text = "Рынок урожая";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title;
        private Label payerName;
        private Label sellerName;
        private Button switchButton;
        private Label financialCapital;
        private ComboBox allProducts;
        private TextBox productCount;
        private Label label1;
        private Label exchangeSum;
        private Button exchangeButton;
        private Label productCost;
    }
}