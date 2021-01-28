using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UebungMVC_V10.Models.DBModels;

namespace UebungMVC_V10.Models.VModels
{
    public class DataVM
    {

        /// <summary>
        /// Konstruktor damit DataVM die Daten von Datum übernimmt
        /// somit muss man nichts mehr im Controller machen
        /// </summary>
        /// <param name="data"></param>
        public DataVM(Datum data)
        {
            DatumID = data.DatumID;
            AnfangDateTime = data.AnfangDateTime;
            EndeDateTime = data.EndeDateTime;
            AbstandDateTimeText = ((TimeSpan)(data.EndeDateTime - data.AnfangDateTime)).Days.ToString();
        }

        /// <summary>
        /// zweiter Konstruktor für View 
        /// </summary>
        public DataVM()
        {
        }

        public int DatumID { get; set; }

        [DataType(DataType.Date), Display(Name = "AnfangsZeit")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? AnfangDateTime { get; set; }

        [DataType(DataType.Date), Display(Name = "EndZeit")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [ValidationDateTime]
        public DateTime? EndeDateTime { get; set; }

        //[DataType(DataType.DateTime), Display(Name = "Stunden")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string AbstandDateTimeText { get; set; }


    }
}