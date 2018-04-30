//-----------------------------------------------------------------------
// <copyright file="GroupDetailViewModel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Mobile.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Input;
    using Spelling.Mobile.Domain;
    using Spelling.Mobile.Domain.Enums;
    using Spelling.Mobile.Infraestructure;
    using Spelling.Mobile.Sevices;
    using Spelling.Mobile.Views;
    using Xamarin.Forms;

    /// <summary>
    /// Group Detail View Model
    /// </summary>
    public class GroupDetailViewModel : BaseViewModel
    {
        /// <summary>
        /// The rest service
        /// </summary>
        private readonly IRestService restService;

        /// <summary>
        /// The work context
        /// </summary>
        private readonly IWorkContext workContext;

        /// <summary>
        /// The best score
        /// </summary>
        private BestScoreModel bestScore;

        /// <summary>
        /// The can show best score
        /// </summary>
        private bool canShowBestScore = false;

        /// <summary>
        /// The latest games
        /// </summary>
        private IList<GameModel> latestGames;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupDetailViewModel"/> class.
        /// </summary>
        /// <param name="restService">The rest service.</param>
        /// <param name="workContext">The work context.</param>
        public GroupDetailViewModel(
            IRestService restService,
            IWorkContext workContext)
        {
            this.restService = restService;
            this.workContext = workContext;

            this.BeginGame = new Command(this.BeginGameCommand);
        }

        /// <summary>
        /// Gets the begin game.
        /// </summary>
        /// <value>
        /// The begin game.
        /// </value>
        public ICommand BeginGame { get; private set; }

        /// <summary>
        /// Gets or sets the best score.
        /// </summary>
        /// <value>
        /// The best score.
        /// </value>
        public BestScoreModel BestScore
        {
            get => this.bestScore;

            set
            {
                this.SetValue(ref this.bestScore, value);
                this.CanShowBestScore = this.bestScore != null;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance can show best score.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can show best score; otherwise, <c>false</c>.
        /// </value>
        public bool CanShowBestScore
        {
            get => this.canShowBestScore;
            set => this.SetValue(ref this.canShowBestScore, value);
        }

        /// <summary>
        /// Gets the type of the group.
        /// </summary>
        /// <value>
        /// The type of the group.
        /// </value>
        public GroupType GroupType { get; private set; }

        /// <summary>
        /// Gets or sets the latest games.
        /// </summary>
        /// <value>
        /// The latest games.
        /// </value>
        public IList<GameModel> LatestGames
        {
            get => this.latestGames;

            set => this.SetValue(ref this.latestGames, value);
        }

        /// <summary>
        /// Sets the type of the group.
        /// </summary>
        /// <param name="groupType">Type of the group.</param>
        public void SetGroupType(GroupType groupType)
        {
            this.GroupType = groupType;

            this.LoadBestScore();

            this.LoadLatestGames();
        }

        /// <summary>
        /// Begins the game command.
        /// </summary>
        private async void BeginGameCommand()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new NewGameView(this.GroupType));
        }

        /// <summary>
        /// Loads the best score.
        /// </summary>
        private async void LoadBestScore()
        {
            var filter = new BestScoreFilterModel
            {
                PageSize = 1,
                GroupType = this.GroupType
            };

            this.BestScore = (await this.restService.Get<BestScoreFilterModel, PaginationResponseModel<BestScoreModel>>("http://10.0.2.2:52017/api/v1/bestscores", filter, this.workContext.CurrentToken.Access_Token))
                .Results.FirstOrDefault();
        }

        /// <summary>
        /// Loads the latest games.
        /// </summary>
        private async void LoadLatestGames()
        {
            var filter = new GameFilterModel
            {
                PageSize = 5,
                OrderBy = "Newest",
                UserId = this.workContext.CurrentUser.Id,
                GroupType = this.GroupType
            };

            this.LatestGames = (await this.restService.Get<GameFilterModel, PaginationResponseModel<GameModel>>("http://10.0.2.2:52017/api/v1/games", filter, this.workContext.CurrentToken.Access_Token)).Results;
        }
    }
}