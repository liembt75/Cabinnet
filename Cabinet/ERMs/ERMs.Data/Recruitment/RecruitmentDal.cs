using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class RecruitmentDal
    {
        public object GetRecruitmentCandidate()
        {
            using (CMSEntities context = new CMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforCMSModel))
            {
                return context.RecruitmentCandidates.OrderByDescending(i => i.Modified).ThenByDescending(i => i.Created).ToList();
                //return context.RecruitmentCandidate.
            }
        }
    }
}
