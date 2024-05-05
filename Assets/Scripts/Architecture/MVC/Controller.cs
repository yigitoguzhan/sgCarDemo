public abstract class Controller<TModel, TView>
        where TModel : Model
        where TView : View<TModel>
{
    #region Model

    protected TModel _model;
    public TModel Model => _model;

    #endregion

    #region View

    protected TView _view;
    public TView View => _view;

    #endregion


    #region Init -> OnInit

    public void Init(TModel model, TView view)
    {
        _model = model;
        _view = view;

        OnInit();
    }

    protected virtual void OnInit()
    {
    }

    #endregion

    #region DeInit -> OnDeInit

    public void DeInit()
    {
        Hide();

        OnDeInit();

        _model = null;
        _view = null;
    }

    protected virtual void OnDeInit()
    {
    }

    #endregion


    #region Model: Set

    public void SetModel(TModel model)
    {
        _model = model;
        _view.SetModel(_model);
    }

    #endregion


    #region Show -> OnShow

    public void Show()
    {
        _view.SetModel(_model);
        _view.Show();

        OnShow();

        OnAddEvents();
    }

    protected abstract void OnShow();

    #endregion

    #region Hide -> OnHide

    public void Hide()
    {
        OnRemoveEvents();

        _view.Hide();

        OnHide();
    }

    protected abstract void OnHide();

    #endregion


    #region Events: OnAdd | OnRemove

    protected abstract void OnAddEvents();
    protected abstract void OnRemoveEvents();

    #endregion
}

public abstract class Controller<TModel, TData, TView>
    where TModel : Model<TData>
    where TData : ModelData
    where TView : View<TModel, TData>
{
    #region Model

    protected TModel _model;
    public TModel Model => _model;

    #endregion

    #region View

    protected TView _view;
    public TView View => _view;

    #endregion


    #region Init -> OnInit

    public void Init(TModel model, TView view)
    {
        _model = model;
        _view = view;

        OnInit();
    }

    protected virtual void OnInit()
    {
        // Override
    }

    #endregion

    #region DeInit -> OnDeInit

    public void DeInit()
    {
        Hide();

        OnDeInit();

        _model = null;
        _view = null;
    }

    protected virtual void OnDeInit()
    {
        // Override
    }

    #endregion


    #region Model: Set

    public void SetModel(TModel model)
    {
        _model = model;
        _view.SetModel(_model);
    }

    #endregion


    #region Show -> OnShow

    public void Show()
    {
        _view.SetModel(_model);
        _view.Show();

        OnShow();

        OnAddEvents();
    }

    protected abstract void OnShow();

    #endregion

    #region Hide -> OnHide

    public void Hide()
    {
        OnRemoveEvents();

        _view?.Hide();

        OnHide();
    }

    protected abstract void OnHide();

    #endregion


    #region Events: OnAdd | OnRemove

    protected abstract void OnAddEvents();
    protected abstract void OnRemoveEvents();

    #endregion
}