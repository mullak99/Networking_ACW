﻿using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace mullak99.ACW.NetworkACW.LCHLib.mUI
{
    public class TextBoxWriter : TextWriter
    {
        TextBox _output = null;

        public TextBoxWriter(TextBox output)
        {
            _output = output;
        }

        public override void Write(char value)
        {
            base.Write(value);
            _output.AppendText(value.ToString());
        }

        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }

    public class RichTextBoxWriter : TextWriter
    {
        RichTextBox _output = null;

        public RichTextBoxWriter(RichTextBox output)
        {
            _output = output;
        }

        public override void Write(char value)
        {
            _output.AppendText(value.ToString());
        }

        public override void WriteLine(string line)
        {
            AppendWithColour(line);
        }

        private void AppendWithColour(string text)
        {
            if (text.Contains("DEBUG]"))
            {
                _output.SelectionStart = _output.TextLength;
                _output.SelectionLength = 0;
                _output.SelectionColor = Color.Violet;
                _output.AppendText(text.ToString());
                _output.SelectionColor = _output.ForeColor;
            }
            else if (text.Contains("WARN]"))
            {
                _output.SelectionStart = _output.TextLength;
                _output.SelectionLength = 0;
                _output.SelectionColor = Color.Yellow;
                _output.AppendText(text.ToString());
                _output.SelectionColor = _output.ForeColor;
            }
            else if (text.Contains("ERROR]"))
            {
                _output.SelectionStart = _output.TextLength;
                _output.SelectionLength = 0;
                _output.SelectionColor = Color.Red;
                _output.AppendText(text.ToString());
                _output.SelectionColor = _output.ForeColor;
            }
            else
            {
                _output.SelectionStart = _output.TextLength;
                _output.SelectionLength = 0;
                _output.SelectionColor = Color.LightGray;
                _output.AppendText(text.ToString());
            }

            _output.AppendText(Environment.NewLine);
        }

        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}
