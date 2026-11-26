using BusinessLogic;
using Model;
using Shared;

namespace Presenter
{

    internal class EntityPresenter
    {
        private IModel<Farmer> model;

        public EntityPresenter(IView view, IModel<Farmer> model)
        {
            this.model = model;

        }
    }
}
