using System;
using System.Collections.Generic;
using System.Text;

using Bramble.Core;

namespace Malison.Core
{
    public interface IWriter
    {
        void Write(char ascii);
        void Write(Glyph glyph);
        void Write(Character character);
        void Write(string text);
        void Write(CharacterString text);

        void Scroll(Vec offset, Func<Vec, Character> scrollOnCallback);
        void Scroll(int x, int y, Func<Vec, Character> scrollOnCallback);

        void Clear();

        void Fill(Glyph glyph);

        void DrawBox(bool isDouble, bool isContinue);

        ITerminal CreateWindow();
        ITerminal CreateWindow(Rect bounds);
    }

    public interface IWriterColor : IWriter
    {
        IWriter this[TermColor foreColor] { get; }
        IWriter this[TermColor foreColor, TermColor backColor] { get; }
        IWriter this[ColorPair color] { get; }
    }

    public interface IWriterPosColor : IWriterColor
    {
        IWriterColor this[Vec pos] { get; }
        IWriterColor this[int x, int y] { get; }
        IWriterColor this[Rect rect] { get; }
        IWriterColor this[Vec pos, Vec size] { get; }
        IWriterColor this[int x, int y, int width, int height] { get; }
    }

    public interface ITerminal : IReadableTerminal, IWriterPosColor
    {
        void Set(Vec pos, Character value);
        void Set(int x, int y, Character value);
    }
}