using Dijkstra.CustomGraph;
using Dijkstra.Formatting;
using Dijkstra.MatrixManipulations;
using Dijkstra.MatrixManipulations.CustomList;
using Dijkstra.OptionsMenu;

namespace Dijkstra
{
    public class AlghoritmLauncher
    {
        private string _filePath;
        private Graph _graph;
        private Container _container;
        private MatrixFiller _matrixFiller;
        private GraphCreator _graphCreator;
        private DijkstraAlghoritm _dijkstraAlghoritm;
        private Menu _menu;

        public void SetPath(string filePath) => _filePath = filePath;

        public void Start()
        {
            _matrixFiller = new MatrixFiller(_filePath);
            _matrixFiller.FillMatrix();
            _container = _matrixFiller.RouteToValidator();
            if (_container != null)
            {
                _graphCreator = new GraphCreator(_container);
                _graph = _graphCreator.CreateGraph();
                _graph.Print();
                _dijkstraAlghoritm = new DijkstraAlghoritm(_graph);
                _menu = new Menu();
                _menu.StartMenu(_dijkstraAlghoritm);
            }
            else return;
        }
    }
}
