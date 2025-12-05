using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolBusRouteTrack.DriverSystem
{
    public partial class UserControlRoute : UserControl
    {
        private int _driverId;

        public UserControlRoute(int driverId)
        {
            InitializeComponent();
            _driverId = driverId;
            LoadRouteData();
        }

        private void LoadRouteData()
        {
            throw new NotImplementedException();
        }
    }
}
