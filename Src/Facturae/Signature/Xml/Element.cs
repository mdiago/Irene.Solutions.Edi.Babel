using System;

namespace Irene.Solutions.Edi.Babel.Facturae.Signature.Xml
{    

    /// <summary>
    /// Representa un elmento xml.
    /// </summary>
    public class Element
    {

        /// <summary>
        /// Representa el tag de cierre.
        /// </summary>
        Etag _Etag;

        /// <summary>
        /// Represnta el tag de apertura.
        /// </summary>
        Stag _Stag;

        /// <summary>
        /// Indica si el elemento está formado por 
        /// más elemento xml o es ya un valor primitivo.
        /// </summary>
        bool _IsContainer = true;

        /// <summary>
        /// Indica si el elemento está vacío.
        /// </summary>
        bool _IsEmpty = true;

        /// <summary>
        /// Contenido del elemento xml.
        /// </summary>
        string _Content;

        /// <summary>
        /// Nombre del elemento xml.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// XmlElements nested in this one.
        /// </summary>
        public ElementList Elements = new ElementList();

        /// <summary>
        /// Representa el elemento xml padre.
        /// </summary>
        public Element Parent;

        /// <summary>
        /// Number of spaces to indent the text representation o a XmlElement
        /// </summary>
        public int Indent = 2;

        /// <summary>
        /// Depth of the element respect the main root element
        /// </summary>
        public int Depth
        {
            get
            {
                if (Parent == null)
                    return 0;

                return Parent.Depth + 1;
            }
        }

        /// <summary>
        /// Valor del elemento xml
        /// en caso de no ser un elemento contenedor
        /// de otros.
        /// </summary>
        public string Content
        {
            get
            {
                return _Content;
            }
            set
            {
                _IsContainer = string.IsNullOrEmpty(value);
                _IsEmpty = string.IsNullOrEmpty(value);
                _Content = value;
            }
        }

        /// <summary>
        /// Text representation of a XmlElement with space indent and with line feed between tags.
        /// The line feed is in canonial mode with char value 0x0a.
        /// </summary>
        public string InnerXML
        {
            get
            {

                string result = "";

                if (_IsEmpty)
                {
                    result = _Stag.Xml + Content + _Etag.Xml;
                    return result.PadLeft(result.Length + Depth * Indent);
                }

                if (!_IsContainer)
                {
                    result = _Stag.Xml.PadLeft(_Stag.Xml.Length + Depth * Indent) + Content + _Etag.Xml;
                    return result;
                }

                foreach (Element El in Elements.XmlElements)
                    result += El.InnerXML + (char)10;

                result = _Stag.Xml.PadLeft(_Stag.Xml.Length + Depth * Indent) + (char)10 + result;
                result += _Etag.Xml.PadLeft(_Etag.Xml.Length + Depth * Indent);

                return result;

            }
        }
        /// <summary>
        /// Text representation of a XmlElement without indent spaces and with line feed between tags.
        /// The line feed is in canonial mode with char value 0x0a.
        /// </summary>
        public string InnerWithoutIndentXML
        {
            get
            {
                string result = "";

                if (_IsEmpty)
                {
                    result = _Stag.Xml + Content + _Etag.Xml;
                    return result;
                }
                if (!_IsContainer)
                {
                    result = _Stag.Xml + Content + _Etag.Xml;
                    return result;
                }
                foreach (Element El in Elements.XmlElements)
                    result += El.InnerWithoutIndentXML + (char)10;

                result = _Stag.Xml + (char)10 + result;
                result += _Etag.Xml;

                return result;
            }
        }
        /// <summary>
        /// Text representation of an XmlElement without indent spaces and without line feed.
        /// </summary>
        public string InnerCanXML
        {
            get
            {
                string result = "";

                if (_IsEmpty)
                {
                    result = _Stag.Xml + Content + _Etag.Xml;
                    return result;
                }

                if (!_IsContainer)
                {
                    result = _Stag.Xml + Content + _Etag.Xml;
                    return result;
                }

                foreach (Element El in Elements.XmlElements)
                    result += El.InnerCanXML;

                result = _Stag.Xml + result;
                result += _Etag.Xml;

                return result;
            }
        }

        /// <summary>
        /// Attributes of the XmlElement, because the attributes are placed in Stag, this element is the parent of this array.
        /// This property only returns the object in Stag.
        /// </summary>
        public AttributeList Attributes
        {
            get
            {
                return _Stag.Attributes;
            }
        }

        /// <summary>
        /// Creates a new instance of a FraeXmlElement with empty content.
        /// </summary>
        /// <param name="name">Name of the XmlElement prefixes included.</param>
        public Element(string name)
        {
            if (name == null)
                throw new ArgumentNullException("Property Name can't be a null value");

            Name = name;
            SetTags(name);
        }

        /// <summary>
        /// Creates a new instance of a FraeXmlElement. If a XmlElement has a non empty Content, then it can't hold any XmlElement child in its Elements array.
        /// </summary>
        /// <param name="name">Name of the XmlElement prefixes included.</param>
        /// <param name="content">String content of a XmlElement without nested childs.</param>
        public Element(string name, string content)
        {
            if (name == null)
                throw new ArgumentNullException("Property Name can't be a null value");

            SetTags(name);
            Name = name;
            Content = content;

        }

        /// <summary>
        /// Initialize Tags with the xml expecification, including attributes in the Stag.
        /// </summary>
        /// <param name="name">Name of the XmlElement</param>
        private void SetTags(string name)
        {
            _Etag = new Etag(name);
            _Stag = new Stag(name);
        }

        /// <summary>
        /// Adds an attribute to the array of attributes on the element Stag. No control of duplicates entries.
        /// </summary>
        /// <param name="attribute">Attribute to insert in the array.</param>
        /// <returns>The insrted Attribute</returns>
        public Attribute AddAttribute(Attribute attribute)
        {
            return _Stag.AddAttribute(attribute);
        }

        /// <summary>
        /// Creates a FraeXmlAttribute and insert it into the attributes array of Stag. No control of duplicates entries.
        /// </summary>
        /// <param name="name">Attribute name.</param>
        /// <param name="value">Attribute value.</param>
        /// <returns></returns>
        public Attribute AddAttribute(string name, string value)
        {
            Attribute attribute = new Attribute(name, value);
            return _Stag.AddAttribute(attribute);
        }

        /// <summary>
        /// Creates a FraeXmlAttribute and insert it to the attributes array of Stag in the position determined by the Position argument value.
        ///  No control of duplicates entries.
        /// </summary>
        /// <param name="name">Attribute name.</param>
        /// <param name="value">Attribute value.</param>
        /// <param name="index">Position where the FraeXmlAttribute must be added.</param>
        public void AddAttributeAt(string name, string value, int index)
        {
            Attribute AttIn = new Attribute(name, value);
            _Stag.AddAttributeAt(AttIn, index);
        }

        /// <summary>
        /// Deletes an attribute from the attributtes array in Stag.
        /// </summary>
        /// <param name="name">Name of the attribute to delete. If multiple attributes with the same name, all will be deleted.</param>
        public void DelAttribute(string name)
        {
            _Stag.DelAttribute(name);
        }

        /// <summary>
        /// Añade un elemento xml a Elements.
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Elemento añadido.</returns>
        public Element AddElement(Element element)
        {
            _IsContainer = true;
            _IsEmpty = false;
            element.Parent = this;
            return Elements.Insert(element);
        }

        /// <summary>
        /// Crea una elemento xml y lo añade a Elements.
        /// </summary>
        /// <param name="name">Nombre del elemento.</param>
        /// <returns>Elemento añadido.</returns>
        public Element AddElement(string name)
        {
            _IsContainer = true;
            _IsEmpty = false;
            Element element = new Element(name);
            element.Parent = this;
            return Elements.Insert(element);
        }

        /// <summary>
        /// Añade un elemento a Elements.
        /// </summary>
        /// <param name="name">Nombre.</param>
        /// <param name="content">Contenido.</param>
        /// <returns>Elemento añadido.</returns>
        public Element AddElement(string name, string content)
        {
            _IsContainer = true;
            _IsEmpty = false;
            Element element = new Element(name, content);
            element.Parent = this;
            return Elements.Insert(element);
        }

        /// <summary>
        /// Añade un elemento xml a Elements.
        /// </summary>
        /// <param name="element">Elemento a añadir.</param>
        /// <returns>Elemento añadido.</returns>
        public Element AddElementFirst(Element element)
        {
            _IsContainer = true;
            _IsEmpty = false;
            element.Parent = this;
            return Elements.InsertAt(element, 0);
        }

        /// <summary>
        /// Añade un elemento en la psoción indicada.
        /// </summary>
        /// <param name="element">Elemento xml a añadir.</param>
        /// <param name="index">Posición en la que insertar el elemento.</param>
        /// <returns>Elemento añadido.</returns>
        public Element AddElementAt(Element element, int index)
        {
            _IsContainer = true;
            _IsEmpty = false;
            element.Parent = this;
            return Elements.InsertAt(element, index);
        }

        /// <summary>
        /// Vacía la colección de elementos.
        /// </summary>
        public void Clear()
        {
            Elements.Clear();
        }
    }

}
