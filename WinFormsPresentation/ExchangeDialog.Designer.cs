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
            productTotalCount = new Label();
            exchangeSum = new Label();
            exchangeButton = new Button();
            productCost = new Label();
            label2 = new Label();
            label1 = new Label();
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
            payerName.BorderStyle = BorderStyle.FixedSingle;
            payerName.Location = new Point(12, 94);
            payerName.Name = "payerName";
            payerName.Size = new Size(387, 56);
            payerName.TabIndex = 1;
            payerName.Text = "Покупатель: ";
            payerName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // sellerName
            // 
            sellerName.BorderStyle = BorderStyle.FixedSingle;
            sellerName.Location = new Point(498, 95);
            sellerName.Name = "sellerName";
            sellerName.Size = new Size(387, 56);
            sellerName.TabIndex = 2;
            sellerName.Text = "Продавец: ";
            sellerName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // switchButton
            // 
            switchButton.Font = new Font("Segoe UI", 10F);
            switchButton.Location = new Point(405, 95);
            switchButton.Name = "switchButton";
            switchButton.Size = new Size(87, 56);
            switchButton.TabIndex = 3;
            switchButton.Text = "<->";
            switchButton.UseVisualStyleBackColor = true;
            switchButton.Click += switchButton_Click;
            // 
            // financialCapital
            // 
            financialCapital.BorderStyle = BorderStyle.FixedSingle;
            financialCapital.Location = new Point(13, 176);
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
            allProducts.Location = new Point(669, 221);
            allProducts.Name = "allProducts";
            allProducts.Size = new Size(182, 33);
            allProducts.TabIndex = 5;
            allProducts.SelectedIndexChanged += allProducts_SelectedIndexChanged;
            // 
            // productCount
            // 
            productCount.Location = new Point(70, 283);
            productCount.Name = "productCount";
            productCount.Size = new Size(150, 31);
            productCount.TabIndex = 6;
            productCount.KeyDown += LeaveEditingOnEnter;
            productCount.Validating += productCount_Validating;
            // 
            // productTotalCount
            // 
            productTotalCount.BorderStyle = BorderStyle.FixedSingle;
            productTotalCount.Location = new Point(633, 299);
            productTotalCount.Name = "productTotalCount";
            productTotalCount.Size = new Size(252, 32);
            productTotalCount.TabIndex = 7;
            productTotalCount.Text = "Количество: ";
            productTotalCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // exchangeSum
            // 
            exchangeSum.BorderStyle = BorderStyle.FixedSingle;
            exchangeSum.Location = new Point(289, 221);
            exchangeSum.Name = "exchangeSum";
            exchangeSum.Size = new Size(335, 56);
            exchangeSum.TabIndex = 8;
            exchangeSum.Text = "Итоговая сумма: ";
            exchangeSum.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // exchangeButton
            // 
            exchangeButton.Location = new Point(367, 297);
            exchangeButton.Name = "exchangeButton";
            exchangeButton.Size = new Size(202, 34);
            exchangeButton.TabIndex = 9;
            exchangeButton.Text = "Совершить сделку";
            exchangeButton.UseVisualStyleBackColor = true;
            exchangeButton.Click += exchangeButton_Click;
            // 
            // productCost
            // 
            productCost.BorderStyle = BorderStyle.FixedSingle;
            productCost.Location = new Point(633, 267);
            productCost.Name = "productCost";
            productCost.Size = new Size(252, 32);
            productCost.TabIndex = 10;
            productCost.Text = "Цена: ";
            productCost.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Location = new Point(12, 223);
            label2.Name = "label2";
            label2.Size = new Size(271, 108);
            label2.TabIndex = 11;
            label2.Text = "Количество выбранного товара:";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Location = new Point(633, 176);
            label1.Name = "label1";
            label1.Size = new Size(252, 91);
            label1.TabIndex = 12;
            label1.Text = "Все товары:";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // ExchangeDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(897, 406);
            Controls.Add(productCost);
            Controls.Add(exchangeButton);
            Controls.Add(exchangeSum);
            Controls.Add(productTotalCount);
            Controls.Add(productCount);
            Controls.Add(allProducts);
            Controls.Add(financialCapital);
            Controls.Add(switchButton);
            Controls.Add(sellerName);
            Controls.Add(payerName);
            Controls.Add(title);
            Controls.Add(label1);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
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
        private ComboBox allProducts;
        private TextBox productCount;
        private Label productTotalCount;
        private Label exchangeSum;
        private Button exchangeButton;
        private Label productCost;
        private Label label2;
        private Label label1;
    }
}