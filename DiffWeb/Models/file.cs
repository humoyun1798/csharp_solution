using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace DiffWeb.Models
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("file")]
    public partial class file
    {
           public file(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string name {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string content {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? datetime {get;set;}

    }
}
