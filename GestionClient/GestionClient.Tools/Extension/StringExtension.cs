using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClient.Tools.Extension
{
    public static class StringExtension
    {
        /// <summary>
        /// Vérifie si la chaine source contiens la chaine toCheck avec des options de comparaison
        /// </summary>
        /// <param name="source">Chaîne de caractère source</param>
        /// <param name="toCheck">Chaîne de caratère à rechercher</param>
        /// <param name="comp">Options de comparaison</param>
        /// <returns>Booléen indiquant si la chaîne source contient la chaîne toCheck</returns>
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source != null && toCheck != null && source.IndexOf(toCheck, comp) >= 0;
        }
    }
}
