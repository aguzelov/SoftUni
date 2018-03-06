﻿namespace Forum.App.UserInterface.Input
{
    using Forum.App.UserInterface.Contracts;
    using System;
    using System.Collections.Generic;

    public class TextArea : IInput
    {
        private int x;
        private int y;
        private int width;
        private int height;
        private int textCursorPosition;
        private Position displayCursor;
        private const int OFFSET = 37;
        private IEnumerable<string> lines = new List<string>();
        private string text = string.Empty;

        private int MaxLength { get; set; }

        public int Left { get => this.x; }
        public int Top { get => this.y; }

        public IEnumerable<string> Lines
        {
            get => this.lines;
        }

        public string Text
        {
            get => this.text;
            set
            {
                this.text = value;
                this.lines = StringProcessor.Split(value);
            }
        }

        public Position DisplayCursor
        {
            get => this.displayCursor;
        }

        public TextArea(int x, int y, int width, int height, int maxLength)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.displayCursor = new Position(x, y);
            this.MaxLength = maxLength;
        }

        public bool AddCharacter(char character)
        {
            if (this.Text.Length < this.MaxLength)
            {
                string stringBefore = this.Text.Substring(0, textCursorPosition);
                string stringAfter = this.Text.Substring(textCursorPosition, this.Text.Length - textCursorPosition);

                this.Text = stringBefore + character + stringAfter;

                this.textCursorPosition++;
                ForumViewEngine.DrawTextArea(this);
                return true;
            }
            return false;
        }

        internal void Write()
        {
            ForumViewEngine.DrawTextArea(this);
            ForumViewEngine.ShowCursor();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey key = keyInfo.Key;
                if (key == ConsoleKey.Backspace)
                {
                    this.Delete();
                }
                else if (key == ConsoleKey.Enter || key == ConsoleKey.Escape || this.Text.Length == this.MaxLength)
                {
                    break;
                }
                else
                {
                    this.AddCharacter(keyInfo.KeyChar);
                }
            }
        }

        public void Delete()
        {
            if (this.textCursorPosition > 0)
            {
                string stringBefore = this.Text.Substring(0, textCursorPosition);
                string stringAfter = this.Text.Substring(textCursorPosition, this.Text.Length - textCursorPosition);

                stringBefore = stringBefore.Substring(0, stringBefore.Length - 1);
                this.Text = stringBefore + stringAfter;
                this.textCursorPosition--;
                ForumViewEngine.DrawTextArea(this);
            }
            this.lines = StringProcessor.Split(this.Text);
        }
    }
}