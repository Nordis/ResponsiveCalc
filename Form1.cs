using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ResponsiveCalc
{
    public partial class ResponsiveCalc : Form
    {
        public ResponsiveCalc()
        {
            InitializeComponent();
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            CountResponsive();
        }

        private void CountResponsive()
        {
            try
            {
                var firstNumber = Decimal.Parse(txtFirst.Text);
                var secondNumber = Decimal.Parse(txtSecond.Text);

                var responsiveRatio = string.Format("{0}%", (firstNumber / secondNumber) * 100).Replace(",", ".");

                Clipboard.SetText(string.Format("{0}; /* {1}px / {2}px */", responsiveRatio, firstNumber, secondNumber));
                //MessageBox.Show(responsiveRatio);

                lstHistory.Items.Insert(0, (string.Format("{0} / {1} = {2}", firstNumber, secondNumber, responsiveRatio)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstHistory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int clickedIndex = lstHistory.IndexFromPoint(e.Location);
            if (clickedIndex != ListBox.NoMatches)
            {
                var item = lstHistory.Items[clickedIndex].ToString();

                var copyText = item.Substring(item.IndexOf("=", StringComparison.Ordinal) + 1).Trim();
                Clipboard.SetText(copyText);
            }
        }
    }
}
