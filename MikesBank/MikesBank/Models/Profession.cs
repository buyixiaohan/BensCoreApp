using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MikesBank.Models
{
    /// <summary>
    /// 职业分类
    /// </summary>
    public class Profession
    {
        /// <summary>
        /// Id.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>

        public int Id { get; set; }

        /// <summary>
        /// 名称.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// 职业编码.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        [MaxLength(6)]
        public string Code { get; set; }

        /// <summary>
        /// 职业分类级别.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        [MaxLength(5)]
        public string Level { get; set; }


        /// <summary>
        /// 下级分类
        /// </summary>
        [Display(Name = "下级分类")]
        public virtual ICollection<Profession> SubCategory { get; set; }

        /// <summary>
        /// 上级分类
        /// </summary>
        [Display(Name = "上级分类")]
        public virtual Profession SupCategory { get; set; }

        /// <summary>
        /// 上级分类
        /// </summary>
        public int? ParentId { get; set; }
    }
}