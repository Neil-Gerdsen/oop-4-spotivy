using System;
using System.Collections.Generic;
using System.Text;

namespace oop4
{
    public interface IPlayable
    {
        void Play();
        void Pause();
        void Next();
        void Stop();
        int Length { get; }
    }
}
