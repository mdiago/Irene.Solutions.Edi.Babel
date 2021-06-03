using System;

namespace Irene.Solutions.Edi.Babel.Facturae.Signature.Xml
{
    /// <summary>
    /// Representa una lista de items.
    /// </summary>
    public class ItemList<T>
    {

        /// <summary>
        /// Matriz que contiene los elementos.
        /// </summary>
        protected T[] _Items = new T[0];

        /// <summary>
        /// Devuelve el atributo del índice
        /// proporcionado.
        /// </summary>
        /// <param name="index">Índice del elemento a devolver.</param>
        /// <returns>Atributo en la posición indicada.</returns>
        public T this[int index]
        {
            get
            {
                return _Items[index];
            }
        }

        /// <summary>
        /// Número de elementos en la lista.
        /// </summary>
        public int Count
        {
            get
            {
                return _Items.Length;
            }
        }

        /// <summary>
        /// Añade un elemento a la matriz de items.
        /// </summary>
        /// <param name="element">Elemento a añadir a la matriz.</param>
        public T Insert(T element)
        {

            T[] result = new T[_Items.Length + 1];

            if (_Items.Length > 0)
                Array.Copy(_Items, result, _Items.Length);

            result[_Items.Length] = element;

            _Items = result;

            return element;

        }

        /// <summary>
        /// Añade un atributo en la posición especificada.
        /// </summary>
        /// <param name="element">Atributo a añadir.</param>
        /// <param name="index">Índice a añadir.</param>
        public T InsertAt(T element, int index)
        {
            int curIndexSource = 0;
            T[] result = new T[_Items.Length + 1];

            for (int curIndex = 0; curIndex < result.Length; curIndex++)
                if (curIndex == index)
                    result[curIndex] = element;
                else
                    result[curIndex] = _Items[curIndexSource++];

            _Items = result;

            return element;

        }

        /// <summary>
        /// Vacía la matriz de elementos.
        /// </summary>
        public void Clear()
        {
            _Items = null;
        }

    }
}
