using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongListReader : MonoBehaviour
{
    public TextAsset songsFile;
    public SongList songList;

    void Start()
    {
        songList = JSONReader<SongList>.ReadJSONIntoClass(songsFile);
    }

    public Song SelectSong(int index)
    {
        return songList.songList[index];
    }
}
