using MetroSuite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

public partial class MainForm : MetroForm
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void guna2TextBox1_TextChanged(object sender, EventArgs e)
    {
        Text = $"StringManager (current character count: {guna2TextBox1.Text.Length})";
        Refresh();
    }

    private void guna2Button1_Click(object sender, EventArgs e)
    {
        try
        {
            guna2TextBox1.Text += Clipboard.GetText();
        }
        catch
        {

        }
    }

    private void guna2Button2_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog().Equals(DialogResult.OK))
        {
            foreach (string path in openFileDialog1.FileNames)
            {
                guna2TextBox1.Text += File.ReadAllText(path);
            }
        }
    }

    private void guna2Button3_Click(object sender, EventArgs e)
    {
        guna2TextBox1.Text = RemoveLineBreaks(guna2TextBox1.Text);
    }

    private void guna2Button4_Click(object sender, EventArgs e)
    {
        guna2TextBox1.Text = RemoveDuplicateLines(guna2TextBox1.Text);
    }

    private void guna2Button5_Click(object sender, EventArgs e)
    {
        guna2TextBox1.Text = SortLines(guna2TextBox1.Text);
    }

    public string RemoveLineBreaks(string text)
    {
        string newText = "";

        foreach (string line in SplitToLines(text))
        {
            if (line.Replace(" ", "").Replace('\t'.ToString(), "") != "")
            {
                if (newText == "")
                {
                    newText = line;
                }
                else
                {
                    newText += "\r\n" + line;
                }
            }
        }

        return newText;
    }

    public string SortLines(string text)
    {
        string newText = "";
        List<string> lines = new List<string>();
        
        foreach (string str in SplitToLines(text))
        {
            lines.Add(str);
        }

        string[] theLines = lines.ToArray();
        Array.Sort(theLines);

        foreach (string str in theLines)
        {
            if (newText == "")
            {
                newText = str;
            }
            else
            {
                newText += "\r\n" + str;
            }
        }

        return newText;
    }

    private IEnumerable<string> SplitToLines(string input)
    {
        if (input == null)
        {
            yield break;
        }

        using (System.IO.StringReader reader = new System.IO.StringReader(input))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }

    private void guna2Button6_Click(object sender, EventArgs e)
    {
        guna2TextBox1.Text = RemoveAllLines(guna2TextBox1.Text);
    }

    public string RemoveDuplicateLines(string text)
    {
        string newText = "";
        List<string> lines = new List<string>();

        foreach (string line in SplitToLines(text))
        {
            lines.Add(line);
        }

        foreach (string line in lines.Distinct().ToArray())
        {
            if (newText == "")
            {
                newText = line;
            }
            else
            {
                newText += "\r\n" + line;
            }
        }

        return newText;
    }

    public string RemoveAllLines(string text)
    {
        string newText = "";

        foreach (string line in SplitToLines(text))
        {
            if (newText == "")
            {
                newText = line;
            }
            else
            {
                newText += line;
            }    
        }

        return newText;
    }

    private void guna2Button7_Click(object sender, EventArgs e)
    {
        guna2TextBox1.Text = guna2TextBox1.Text.Trim().Replace('\t'.ToString(), "");
    }

    private void guna2Button8_Click(object sender, EventArgs e)
    {
        guna2TextBox1.Text += guna2TextBox1.Text;
    }
}