using ERMs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraNavBar;

namespace CrewInfo.Menu
{
    public class VNCrewMenu
    {
        public string RootName { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

        public string RootText { get; set; }   
        
        public int ImageIndex { get; set; }

        public static void GenerateMenuApp(NavBarControl navBar, int userid)
        {
            SystemDAL dbSystem = new SystemDAL();
            List<VNCrewMenu> lstMenu = new List<VNCrewMenu>();
            

            //lstMenu.Add(new VNCrewMenu() { RootName = "", Name = "D.S", Text = "System" });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.S", Name = "D.S.R.01", RootText = "System", Text = "Role", ImageIndex = 0 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.S", Name = "D.S.U.01", RootText = "System", Text = "User", ImageIndex = 1 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.S", Name = "D.S.A.01", RootText = "System", Text = "Activity", ImageIndex = 2 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.S", Name = "D.S.D.01", RootText = "System", Text = "Device", ImageIndex = 3 });

            //lstMenu.Add(new VNCrewMenu() { RootName = "", Name = "D.C", Text = "VN Crew" });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.C", Name = "D.C.T.01", RootText = "VN Crew", Text = "Phân công vị trí", ImageIndex = 4 });            
            lstMenu.Add(new VNCrewMenu() { RootName = "D.C", Name = "D.C.T.03", RootText = "VN Crew", Text = "Cơ cấu chuyến bay", ImageIndex = 5 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.C", Name = "D.C.T.04", RootText = "VN Crew", Text = "Đồng bộ chuyến bay", ImageIndex = 6 });
            //lstMenu.Add(new VNCrewMenu() { RootName = "D.C", Name = "D.C.T.07", RootText = "VN Crew", Text = "Đồng bộ với NetLine", ImageIndex = 35 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.C", Name = "D.C.T.08", RootText = "VN Crew", Text = "Đồng bộ DTV ↔️ OCC", ImageIndex = 35 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.C", Name = "D.C.T.05", RootText = "VN Crew", Text = "Danh sách chuyến bay", ImageIndex = 7 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.C", Name = "D.C.T.06", RootText = "VN Crew", Text = "Bán hàng miễn thuế", ImageIndex = 8 });
            //lstMenu.Add(new VNCrewMenu() { RootName = "D.C", Name = "D.C.T.02", RootText = "VN Crew", Text = "Phân công vị trí (admin)" });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.C", Name = "D.C.R.01", RootText = "VN Crew", Text = "Báo cáo chuyến bay", ImageIndex = 9 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.C", Name = "D.C.R.03", RootText = "VN Crew", Text = "Danh mục báo cáo", ImageIndex = 10 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.C", Name = "D.C.A.01", RootText = "VN Crew", Text = "Đánh giá chất lượng", ImageIndex = 11 });            
            lstMenu.Add(new VNCrewMenu() { RootName = "D.C", Name = "D.C.F.01", RootText = "VN Crew", Text = "Nguyện vọng", ImageIndex = 13 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.C", Name = "D.C.F.02", RootText = "VN Crew", Text = "Loại nguyện vọng", ImageIndex = 14 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.C", Name = "D.C.S.01", RootText = "VN Crew", Text = "Hỗ trợ", ImageIndex = 12 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.C", Name = "D.C.M.01", RootText = "VN Crew", Text = "Tin nhắn", ImageIndex = 15 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.C", Name = "D.C.N.01", RootText = "VN Crew", Text = "Thông báo", ImageIndex = 34 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.C", Name = "D.EU.F.01", RootText = "VN Crew", Text = "Cabin crew", ImageIndex = 33 });

            lstMenu.Add(new VNCrewMenu() { RootName = "D.H", Name = "D.H.C.01", RootText = "Y Tế", Text = "Chứng chỉ sức khỏe", ImageIndex = 17 });
            
            lstMenu.Add(new VNCrewMenu() { RootName = "D.E", Name = "D.E.M.01", RootText = "Exam", Text = "Kết quả thi", ImageIndex = 18 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.E", Name = "D.E.M.04", RootText = "Exam", Text = "Quản lý đề thi", ImageIndex = 19 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.E", Name = "D.E.M.02", RootText = "Exam", Text = "Quản lý loại câu hỏi", ImageIndex = 20 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.E", Name = "D.E.M.03", RootText = "Exam", Text = "Quản lý ngân hàng câu hỏi", ImageIndex = 21 });

            lstMenu.Add(new VNCrewMenu() { RootName = "D.L", Name = "D.L.A.01", RootText = "Ticket", Text = "Quản lý airport", ImageIndex = 26 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.L", Name = "D.L.F.01", RootText = "Ticket", Text = "Quản lý form", ImageIndex = 27 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.L", Name = "D.L.FD.01", RootText = "Ticket", Text = "Quản lý form detail", ImageIndex = 28 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.L", Name = "D.L.R.01", RootText = "Ticket", Text = "Quản lý report", ImageIndex = 29 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.L", Name = "D.L.B.01", RootText = "Ticket", Text = "Quản lý ticket book", ImageIndex = 30 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.L", Name = "D.L.H.01", RootText = "Ticket", Text = "Quản lý lịch sử vé", ImageIndex = 31 });

            lstMenu.Add(new VNCrewMenu() { RootName = "D.B", Name = "D.B.D.01", RootText = "Công việc", Text = "Nhật ký trực briefing", ImageIndex = 32 });
            //lstMenu.Add(new VNCrewMenu() { RootName = "D.B", Name = "D.T.T.01", RootText = "Công việc", Text = "KL giao ban", ImageIndex = 32 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.B", Name = "D.M.F.01", RootText = "Công việc", Text = "KL giao ban", ImageIndex = 32 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.B", Name = "D.M.D.01", RootText = "Công việc", Text = "Dữ liệu giao ban", ImageIndex = 32 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.B", Name = "D.N.T.01", RootText = "Công việc", Text = "DS Tour", ImageIndex = 31 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.B", Name = "D.N.R.01", RootText = "Công việc", Text = "DS Đăng ký", ImageIndex = 31 });

            lstMenu.Add(new VNCrewMenu() { RootName = "D.SV", Name = "D.SV.S.01", RootText = "Survey", Text = "Survey", ImageIndex = 22 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.SV", Name = "D.SV.C.01", RootText = "Survey", Text = "Survey Banking", ImageIndex = 23 });
            //lstMenu.Add(new VNCrewMenu() { RootName = "D.SV", Name = "D.SV.BI.01", RootText = "Survey", Text = "Quản lý ngân hàng câu" });

            lstMenu.Add(new VNCrewMenu() { RootName = "D.O", Name = "D.O.O.01", RootText = "OJT", Text = "OJT", ImageIndex = 24 });
            lstMenu.Add(new VNCrewMenu() { RootName = "D.O", Name = "D.O.C.01", RootText = "OJT", Text = "OJT Banking", ImageIndex = 25 });

            //lstMenu.Add(new VNCrewMenu() { RootName = "D.T", Name = "D.T.T.01", RootText = "Công việc", Text = "KL giao ban", ImageIndex = 16 });

            


            NavBarGroup nodeSystem = null;
            NavBarGroup nodeVNCrew = null;
            NavBarGroup nodeTask = null;
            NavBarGroup nodeYTe = null;
            NavBarGroup nodeExam = null;
            NavBarGroup nodeSurvey = null;
            NavBarGroup nodeTicket = null;
            NavBarGroup nodeBriefing = null;
            NavBarGroup nodeOJT = null;
            NavBarGroup nodeEU = null;
            navBar.BeginUpdate();
            navBar.Groups.Clear();
            navBar.Items.Clear();
            foreach (VNCrewMenu menu in lstMenu)
            {
                switch (menu.RootName)
                {
                    case "D.S":
                        nodeSystem = AddNavBarItem(navBar, nodeSystem, menu);
                        break;
                    case "D.C":
                        nodeVNCrew = AddNavBarItem(navBar, nodeVNCrew, menu);
                        break;
                    case "D.T":
                        nodeTask = AddNavBarItem(navBar, nodeTask, menu);
                        break;
                    case "D.H":
                        nodeYTe = AddNavBarItem(navBar, nodeYTe, menu);
                        break;
                    case "D.E":
                        nodeExam = AddNavBarItem(navBar, nodeExam, menu);
                        break;
                    case "D.SV":
                        nodeSurvey = AddNavBarItem(navBar, nodeSurvey, menu);
                        break;
                    case "D.O":
                        nodeOJT = AddNavBarItem(navBar, nodeOJT, menu);
                        break;
                    case "D.L":
                        nodeTicket = AddNavBarItem(navBar, nodeTicket, menu);
                        break;
                    case "D.B":
                        nodeBriefing = AddNavBarItem(navBar, nodeBriefing, menu);
                        break;
                    case "D.EU":
                        nodeEU = AddNavBarItem(navBar, nodeEU, menu);
                        break;
                }
            }
            if (nodeSystem != null) nodeSystem.Expanded = true;
            if (nodeVNCrew != null) nodeVNCrew.Expanded = true;
            if (nodeTask != null) nodeTask.Expanded = true;
            if (nodeYTe != null) nodeYTe.Expanded = true;
            if (nodeExam != null) nodeExam.Expanded = true;
            if (nodeTicket != null) nodeTicket.Expanded = true;
            if (nodeBriefing != null) nodeBriefing.Expanded = true;
            if (nodeSurvey != null) nodeSurvey.Expanded = true;
            if (nodeOJT != null) nodeOJT.Expanded = true;
            if (nodeEU != null) nodeEU.Expanded = true;
            navBar.EndUpdate();
        }

        private static NavBarGroup AddNavBarItem(NavBarControl navBar, NavBarGroup nodeGroup, VNCrewMenu node)
        {
            USP_GetAllCRUDByUserID_Result crud = UserInfoModel.GetCRUID(node.Name);
#if (DEBUG)
            crud = new USP_GetAllCRUDByUserID_Result();
            crud.R = crud.C = crud.U = crud.D = true;
#endif
            if (crud != null && crud.R.HasValue && crud.R.Value)
            {
                if (nodeGroup == null)
                {
                    nodeGroup = new NavBarGroup(node.RootText);
                    //nodeGroup.LargeImageIndex = nodeGroupImageIndex;
                    navBar.Groups.Add(nodeGroup);
                }
                nodeGroup.ItemLinks.Add(new NavBarItem() { Name = node.Name, Caption = node.Text, SmallImageIndex = node.ImageIndex });
            }
            return nodeGroup;
        }
    }
}
