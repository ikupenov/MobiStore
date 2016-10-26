using System.Windows.Forms;

namespace MobiStore.DesktopClient
{
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            var prompt = new Form
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };

            var textLabel = new Label
            {
                Left = 170,
                Top = 20,
                Width = 200,
                Text = text
            };

            var textBox = new TextBox
            {
                Left = 50,
                Top = 50,
                Width = 300
            };
            textBox.PasswordChar = '*';

            var confirmation = new Button
            {
                Text = "OK",
                Left = 350,
                Width = 100,
                Top = 49,
                DialogResult = DialogResult.OK
            };

            confirmation.Click += (sender, e) => prompt.Close();

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            string result = prompt.ShowDialog() == DialogResult.OK ? textBox.Text : string.Empty;
            return result;
        }
    }
}