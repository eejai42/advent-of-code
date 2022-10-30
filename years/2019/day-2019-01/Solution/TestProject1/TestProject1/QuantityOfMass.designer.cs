using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Extensions;

namespace adventofcode.Lib.DataClasses
{                            
    public partial class QuantityOfMass
    {
        private void InitPoco()
        {
            
            

        }
        
        partial void AfterGet();
        partial void BeforeInsert();
        partial void AfterInsert();
        partial void BeforeUpdate();
        partial void AfterUpdate();

        

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "QuantityOfMassId")]
        public String QuantityOfMassId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "createdTime")]
        public Nullable<DateTime> createdTime { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Mass")]
        public Nullable<Int32> Mass { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Group")]
        public String Group { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "FinalFuelRequired")]
        public Nullable<Int32> FinalFuelRequired { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "FuelRequired")]
        public Nullable<Int32> FuelRequired { get; set; }
    

        

        
        
        private static string CreateQuantityOfMassWhere(IEnumerable<QuantityOfMass> quantitiesOfMass, String forignKeyFieldName = "QuantityOfMassId")
        {
            if (!quantitiesOfMass.Any()) return "1=1";
            else 
            {
                var idList = quantitiesOfMass.Select(selectQuantityOfMass => String.Format("'{0}'", selectQuantityOfMass.QuantityOfMassId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
    }
}
