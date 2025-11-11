using UnityEngine;
using UnityEngine.Serialization;

namespace _1._Project.Scripts
{
	public class AudioClipHelper : MonoBehaviour
	{
		public AudioClip Clip;
		public AudioSource AudioSource;

		public void PlayClip()
		{
			if (AudioSource.isPlaying)
			{
				AudioSource.Stop();
			}

			AudioSource.clip = Clip;
			AudioSource.Play();
		}
	}
}