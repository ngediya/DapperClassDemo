using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Models
{
    [Table("tblBranch")]
    public class Branch
    {
        /// <summary>
        /// Gets or sets the branch identifier.
        /// </summary>
        /// <value>
        /// The branch identifier.
        /// </value>
        [Key]
        public long BranchID { get; set; }

        /// <summary>
        /// Gets or sets the name of the branch.
        /// </summary>
        /// <value>
        /// The name of the branch.
        /// </value>
        public string BranchName { get; set; }
    }
}
