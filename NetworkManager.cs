using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	private const string typeName="UniqueGameName";
	private const string gameName="RoomName";

	private HostData[] hostList;

	public GameObject player;

	private void refreshHostList(){
		MasterServer.RequestHostList (typeName);
	}

	void onMasterServerEvent(MasterServerEvent msEvent){
		if (msEvent == MasterServerEvent.HostListReceived)
			hostList = MasterServer.PollHostList ();
	}

	private void JoinServer(HostData hostData){
		Network.Connect (hostData);
	}

	void onConnectedToServer(){
		Debug.Log ("Server Joined");
		spawnPlayer ();
	}

	void spawnPlayer(){
		Network.Instantiate (player, new Vector2 (0, 0), Quaternion.identity, 0);
	}

	private void startServer(){
		Network.InitializeServer (4, 25000, !Network.HavePublicAddress ());
		//MasterServer.ipAddress = "127.0.0.1";
		MasterServer.RegisterHost (typeName, gameName);
	}

	void OnServerInitialized(){
		Debug.Log ("Server Initialized");
	}

	void OnGUI(){
		if (!Network.isClient && !Network.isServer) {
			if (GUI.Button (new Rect (100, 100, 250, 100), "Start Server"))
				startServer ();
			if (GUI.Button (new Rect (100, 250, 250, 100), "Refresh Hosts"))
				refreshHostList();

			if (hostList!=null){
				for (int i=0; i<hostList.Length; i++){
					if (GUI.Button (new Rect (400, 100+(i*110), 300, 100), hostList[i].gameName))
					    JoinServer(hostList[i]);
				}
			}

		}
	}
	/*private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector3.zero;
	private Vector3 syncEndPosition = Vector3.zero;
	
	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		Vector3 syncPosition = Vector3.zero;
		if (stream.isWriting)
		{
			//syncPosition = rigidbody.position;
			stream.Serialize(ref syncPosition);
		}
		else
		{
			stream.Serialize(ref syncPosition);
			
			syncTime = 0f;
			syncDelay = Time.time - lastSynchronizationTime;
			lastSynchronizationTime = Time.time;
			
			//syncStartPosition = rigidbody.position;
			syncEndPosition = syncPosition;
		}
	}*/

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
