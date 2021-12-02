using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WordGuesser;

public class GameController : MonoBehaviour
{
    public UnityEngine.UI.InputField PlayerGuess;
    public GameObject StartScreen;
    public GameObject PlayScreen;
    public UnityEngine.UI.Text Message;
    public UnityEngine.UI.Button StartButton;
    private WordGuesser.WordGame guessingGame;
    public UnityEngine.UI.Text Info;
    public UnityEngine.UI.Text GetWord;
    public UnityEngine.UI.Text GuessesRemaining;
    public UnityEngine.UI.Text GetGuessedLetters;
    public UnityEngine.UI.Text InfoAfterGuess;


    public void SubmitGuess()
    {
        
        string result = this.guessingGame.CheckGuess(PlayerGuess.text);
        Debug.Log(result);
        Info.text = result;
        GetWord.text = this.guessingGame.GetWord();
        GetGuessedLetters.text = this.guessingGame.GetGuessedLetters();
        GuessesRemaining.text = $"{this.guessingGame.GetGuessLimit() - this.guessingGame.GetIncorrectGuesses()}";
        InfoAfterGuess.text = this.guessingGame.CheckGuess(PlayerGuess.text);
    }
    
    public void StartGame()
    {
        this.guessingGame = new WordGuesser.WordGame("apple", 5);
        Debug.Log(this.guessingGame.GetWord());
        Debug.Log(this.guessingGame.GetFullWord());
        
        this.Message.text = "Can you save the snowman?";
        this.StartButton.gameObject.SetActive(false);
        StartScreen.SetActive(false);
        PlayScreen.SetActive(true);
    }

    public void OpenStartScreen()
    {
        StartScreen.SetActive(true);
        PlayScreen.SetActive(false);
    }
    public void Start(){
        StartScreen.SetActive(true);
        PlayScreen.SetActive(false);
    }
} 

public void isGameOver()
{
    this.StartScreen.SetActive(false);
    this.PlayScreen.SetActive(false);
    this.GameOver.SetActive(true);
    this.GameWon.SetActive(false);
    CorrectWord.text = this.guessingGame.GetWord();
}

public void isGameWon()
{
    this.StartScreen.SetActive(false);
    this.PlayScreen.SetActive(false);
    this.GameOver.SetActive(false);
    this.GameWon.SetActive(true);
}