using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepad_v2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string fileName = openFileDialog1.FileName;
            toolStripStatusLabel1.Text = Path.GetFileNameWithoutExtension(fileName);
            toolStripStatusLabel2.Text = Cursor.Position.ToString();


        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            openFileDialog1.Filter = "Txt files(*.txt)|*.txt| HTML files(*.html)|*html| Csharp files(*.cs)|*.cs| Rich files(*.rtf)|*.rtf|All files(*.*)|*.*||"; // name filter|some filter
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text  = File.ReadAllText(openFileDialog1.FileName);
            }

            MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "(*.txt; *.cs; *html; *rtf) | *.txt; *.cs; *.html; *rtg";
            string file = openFileDialog1.FileName;
            RichTextBoxStreamType stream_type;
            // Checks the extension of the file to save
            if (file.Contains(".txt"))
                stream_type = RichTextBoxStreamType.PlainText;
            else
                stream_type = RichTextBoxStreamType.RichText;
            richTextBox1.SaveFile(file, stream_type);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Txt files(*.txt)|*.txt| HTML files(*.html)|*html| Csharp files(*.cs)|*.cs| Rich files(*.rtf)|*.rtf|All files(*.*)|*.*||"; // name filter|some filter
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                switch (Path.GetExtension(path))
                {
                    case ".txt":
                        File.WriteAllText(path, richTextBox1.Text);
                        break;

                    case ".rtf":
                        richTextBox1.SaveFile(path, RichTextBoxStreamType.RichText);
                        break;
                    default:
                        break;
                }
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font current = richTextBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                if (richTextBox1.SelectionFont.Bold == true)
                    newFontStyle = FontStyle.Regular;
                else
                    newFontStyle = FontStyle.Bold;
                richTextBox1.SelectionFont = new Font(current.FontFamily, current.Size, newFontStyle);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font current = richTextBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                if (richTextBox1.SelectionFont.Italic == true)
                    newFontStyle = FontStyle.Regular;
                else
                    newFontStyle = FontStyle.Italic;
                richTextBox1.SelectionFont = new Font(current.FontFamily, current.Size, newFontStyle);

            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font current = richTextBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                if (richTextBox1.SelectionFont.Underline == true)
                    newFontStyle = FontStyle.Regular;
                else
                    newFontStyle = FontStyle.Underline;
                richTextBox1.SelectionFont = new Font(current.FontFamily, current.Size, newFontStyle);
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedIndex == 0)
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            else if (toolStripComboBox1.SelectedIndex == 1)
                richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            else if (toolStripComboBox1.SelectedIndex == 2)
                richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;
            fontDialog1.Font = richTextBox1.Font;
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
                richTextBox1.SelectionColor = fontDialog1.Color;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "https://chorrnyinc.com";
        }
    }
}
