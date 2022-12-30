using UnityEngine;

[System.Serializable]
public class Song 
{
    public string name;
    public float duration;
    public string notesEasy;
    public string notesMedium;
    public string notesHard;

    public static Song CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Song>(jsonString);
    }

    public void ShowSongInfo()
    {
        Debug.Log("Song Name:" + name);
        Debug.Log("Duration:" + duration);
        Debug.Log("easy Lyrics:" + notesEasy);
        Debug.Log("medium Lyrics:" + notesMedium);
        Debug.Log("hard Lyrics:" + notesHard);
    }
}

[System.Serializable]
public class SongList
{
    public Song[] songList;
}
