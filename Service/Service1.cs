using System.ServiceProcess;
using Common;
using System.Threading.Tasks;

namespace Service
{
    public partial class Service1 : ServiceBase
    {
        private ProcessingSetupAndRun logic = new ProcessingSetupAndRun();

        public Service1()
        {
            InitializeComponent();
            logic.Setup();
        }

        protected override void OnStart(string[] args)
        {

            Task.Factory.StartNew(() =>
            {
                Parallel.Invoke(() =>
                {
                    logic.Run();
                });
            });

        }

        protected override void OnStop()
        {
        }
    }
}
