using Logging.Interfaces;
using Logging.Layouts;
using System;

namespace Logging.Factories
{
    public class LayoutFactory
    {
        public ILayout CreateLayout(LayoutsType type)
        {
            switch (type)
            {
                case LayoutsType.SimpleLayout:
                    return new SimpleLayout();

                case LayoutsType.XmlLayout:
                    return new XmlLayout();

                default:
                    throw new ArgumentException("Invalid layout type!");
            }
        }
    }
}