using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UebungMVC_V10.Models.VModels;

namespace UebungMVC_V10.Models.DBModels
{
    public class Datum
    {
        public Datum(DataVM data)
        {
            DatumID = data.DatumID;
            AnfangDateTime = data.AnfangDateTime;
            EndeDateTime = data.EndeDateTime;
            AbstandDateTimeText = (data.EndeDateTime - data.AnfangDateTime).ToString();
        }

        public Datum()
        {

        }

        [Key]
        public int DatumID { get; set; }

        [DataType(DataType.Date), Display(Name = "AnfangsZeit")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? AnfangDateTime { get; set; }

        [DataType(DataType.Date), Display(Name = "EndZeit")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EndeDateTime { get; set; }

        [DataType(DataType.Date), Display(Name = "Abstand")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public string AbstandDateTimeText { get; set; }


    }
}