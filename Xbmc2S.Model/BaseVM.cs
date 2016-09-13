using System.Diagnostics;

namespace Xbmc2S.Model
{
    public abstract class BaseVM:BindableBase
    {
        protected IAppContext _appContext;
        
        private string _label;
        private string _secondLabel;



        public int Id { get; set; }
        public VideoImages Images { get; private set; }


        public BaseVM(KODIRPC.Video.Details.Base baseDetails, IAppContext appContext):this(appContext)
        {


            Images= new VideoImages(appContext, baseDetails);


        }
        public BaseVM( IAppContext appContext){
            _appContext = appContext;
            Images= new VideoImages(_appContext);
        }


        public BaseVM(string thumb, IAppContext appContext)
            : this(appContext)
        {
            Images = new VideoImages(appContext, thumb); 
            
        }
        public BaseVM(KODIRPC.Media.Details.Base baseDetails, IAppContext appContext)
            : this(appContext)
        {
            Images= new VideoImages(appContext, baseDetails);
        }

        protected void SetImage(KODIRPC.Media.Details.Base baseDetails)
        {
            Images.SetImages(baseDetails);

        }
        protected void SetImage(VideoImages images)
        {
            Images = images;
            OnPropertyChanged("Images");

        }



        public string Label
        {
            get { return _label; }
            protected set { _label = value; OnPropertyChanged();}
        }       
        
        public string SecondLabel
        {
            get { return _secondLabel; }
            protected set { _secondLabel = value; OnPropertyChanged(); }
        }

        public bool WatchedCheck
        {
            get { return _watchedCheck; }
            set { SetProperty(ref _watchedCheck, value); }
        }


        protected bool _watchedCheck;


    }
}