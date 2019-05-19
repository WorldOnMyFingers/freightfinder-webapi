using System;
using System.Drawing;

namespace FreightFinder.Core.IServices
{
    public interface IImageServices
    {
        Byte[] getImage(string url);

    }
}
