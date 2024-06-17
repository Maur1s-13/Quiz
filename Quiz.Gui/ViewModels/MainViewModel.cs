using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quiz.Core;
using Quiz.Gui.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.QuestionProviders;




namespace Quiz.Gui.ViewModels;

public partial class MainViewModel : ObservableObject
{
    #region PopUp
    [ObservableProperty]
    ObservableCollection<Player> _players = [];

    [ObservableProperty]
    private Player? _currentPlayer = null;

    private int _playerId = 1;

    [ObservableProperty]
    bool _showUsersPopup = false;

    [RelayCommand]
    void ManageUsers()
    {
        this.ShowUsersPopup = true;
    }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddPlayerCommand))]
    private string _newPlayerName = string.Empty;

    private bool IsValidPlayerName => NewPlayerName != string.Empty;

    [RelayCommand(CanExecute = nameof(IsValidPlayerName))]
    void AddPlayer()
    {
        Player p = new Player(this._playerId, this.NewPlayerName);
        this.Players.Add(p);

        this._playerId++;
        this.NewPlayerName = string.Empty;
    }

    [ObservableProperty]
    private Question? _activeQuestion = null;
    private void LoadNextQuestion()
    {
        ActiveQuestion = _activePlay.Current;
    }

    private void LoadNextPlayer()
    {

        _activePlay = _activeRound.Current;

        // start session for this player
        _activePlay.Start();

        CurrentPlayer = _activePlay.Player;

        // get question
        if (_activePlay.MoveNext())
        {
            LoadNextQuestion();
        }

        OnPropertyChanged(nameof(IsRoundInit));
        OnPropertyChanged(nameof(IsRoundActive));
        OnPropertyChanged(nameof(IsRoundDone));

    }

    // [ObservableProperty]
    // private string _name = string.Empty;



    private string _name = string.Empty;

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            SetProperty(ref _name, value);
        }
    }

    public MainViewModel()
    {
        this.Players.CollectionChanged += Players_CollectionChanged;
    }

    private void Players_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Remove)
        {
             this.AddRoundCommand.NotifyCanExecuteChanged();
        }
    }
    #endregion

    #region Game
    private Game _game = new Game();

    [ObservableProperty]
    bool _gameHasRound = false;

    private GameRound? _activeRound = null;

    private Play? _activePlay = null;

    [ObservableProperty]
    ObservableCollection<QuestionProviderItem> _rounds = [];

    Random gen = new Random();

    private bool UsersAvailable => this.Players.Count > 0;

    public bool IsRoundInit => this._game.Count > 0 && this._game.GetLatestRound().Status == GameRoundStatus.Init;

    public bool IsRoundActive => this._game.Count > 0 && this._game.GetLatestRound().Status == GameRoundStatus.Active;

    public bool IsRoundDone => this._game.Count > 0 && this._game.GetLatestRound().Status == GameRoundStatus.Done;

    public string? RoundTopic
    {
        get
        {
            if (this._game.Count > 0)
            {
                return this._game.GetLatestRound().Topic;
            }

            return null;
        }
    }

    #region Command
    [RelayCommand(CanExecute = nameof(UsersAvailable))]
    void AddRound()
    {
        IQuestionProvider staticProvider;

        // get random providers
        // gen.Next returns 0 or 1
        if (gen.Next(0, 2) == 0)
        {
            staticProvider = new StaticQuestions();
        }
        else
        {
            staticProvider = new HistoryQuestionProvider();
        }

        // create an item and generate image
        QuestionProviderItem item = new QuestionProviderItem(staticProvider);

        // add item to game rounds (for the display)
        this.Rounds.Add(item);

        // add round to game object
        _game.AddRound(staticProvider, true, 5);

        // add each player to the game object
        foreach (Player p in Players)
        {
            _game.AddPlayerToLatestRound(p);
        }

        OnPropertyChanged(nameof(RoundTopic));

        OnPropertyChanged(nameof(IsRoundInit));
        OnPropertyChanged(nameof(IsRoundActive));
        OnPropertyChanged(nameof(IsRoundDone));

        this.GameHasRound = true;
    }


    [RelayCommand]
    void StartRound()
    {
        _activeRound = _game.GetLatestRound();
        _activeRound.Start();

        // next play
        var hasPlayer = _activeRound.MoveNext();

        if (hasPlayer)
        {
            LoadNextPlayer();
        }

    }

    [RelayCommand]
    void SelectAnswer(IAnswer answer)
    {
        var selAnswer = ActiveQuestion.Answers.FirstOrDefault<IAnswer>(a => a.Id == answer.Id);

        if (selAnswer != null)
        {
            selAnswer.IsChecked = true;
        }

        _activePlay.ValidateCurrentQuestion();

        if (_activePlay.IsActive && _activePlay.MoveNext())
        {
            LoadNextQuestion();
        }
        else if (_activeRound.Status == GameRoundStatus.Active && _activeRound.MoveNext())
        {
            LoadNextPlayer();
        }
        else
        {
            // check round status
            OnPropertyChanged(nameof(IsRoundInit));
            OnPropertyChanged(nameof(IsRoundActive));
            OnPropertyChanged(nameof(IsRoundDone));
            OnPropertyChanged(nameof(BestPlayer));
        }

        // check play status
        OnPropertyChanged(nameof(IsPlayInit));
        OnPropertyChanged(nameof(IsPlayActive));
        OnPropertyChanged(nameof(IsPlayDone));

    }

    public Player? BestPlayer
    {
        get
        {
            if (_game.Count > 0)
            {
                if (_game.GetLatestRound() != null && _game.GetLatestRound().BestPlay() != null)
                {
                    return _game.GetLatestRound().BestPlay().Player;
                }
                return null;
            }
            else
            {
                return null;
            }
        }
    }

    public bool IsPlayInit => this._activePlay != null && this._activePlay.Status == PlayStatus.Init;

    public bool IsPlayActive => this._activePlay != null && this._activePlay.Status == PlayStatus.Active;

    public bool IsPlayDone => this._activePlay != null && this._activePlay.Status == PlayStatus.Done;

    #endregion








    #endregion
}
