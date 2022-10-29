using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Extensions;

namespace adventofcode.Lib.DataClasses
{                            
    public partial class AirtableAttachment
    {
        private void InitPoco()
        {
            
            

        }
        
        partial void AfterGet();
        partial void BeforeInsert();
        partial void AfterInsert();
        partial void BeforeUpdate();
        partial void AfterUpdate();

        

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "AttachmentsId")]
        public String AttachmentsId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "url")]
        public String url { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "filename")]
        public String filename { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "size")]
        public Nullable<Int32> size { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "type")]
        public String type { get; set; }
    

        

        
        
        
    }
}
