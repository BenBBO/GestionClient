using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClient.Manager.Interface
{
    public interface ICrudManager<T>
    {
        /// <summary>
        /// Mise à jour d'un élément 
        /// </summary>
        /// <param name="item">Element à mettre à jour</param>
         void UpdateItem(T item);

        /// <summary>
        /// Suppression d'un élément par son Id
        /// </summary>
        /// <param name="item">Element à supprimer</param>
         void DeleteItem(T item);

        /// <summary>
        /// Création d'un élément
        /// </summary>
        /// <param name="item">Données de l'élement à créer</param>
        /// <returns>Id de l'élément créé</returns>
         void CreateItem(T item);

        /// <summary>
        /// Récupération de l'ensemble des éléments de type T
        /// </summary>
        /// <returns>Enumerable d'élements de type T</returns>
        IEnumerable<T> GetAll();

    }
}
