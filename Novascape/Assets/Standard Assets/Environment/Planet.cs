using UnityEngine;
using System;
using System.Collections.Generic;
using Random=UnityEngine.Random;

public class Planet : MonoBehaviour {
	public int[,] blocks;
	public int radius;
	public int[] res = {1, 4, 9, 17, 28};
	public GameObject[] blockObjects;

	string world;

	private Transform worldHolder;

	// Use this for initialization
	void Start () {
		radius = 20;
		blocks = new int[radius*2+20, radius*2+20];
		//blocks = new int[50, 50];

		for (int i=0; i<blocks.GetLength(0); i++) {
			for (int j=0; j<blocks.GetLength(1); j++){
				blocks[i, j]=0;
			}
		}

		worldHolder = new GameObject ("world").transform;

		generateBlocks(blocks.GetLength(0)/2, blocks.GetLength(1)/2);
		generateCaves (blocks.GetLength (0) / 2, blocks.GetLength (1) / 2);
		generateResources ();

		printWorld ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void printWorld(){
		for (int i=0; i<blocks.GetLength(0); i++) {
			for (int j=0; j<blocks.GetLength(1); j++) {
				world+=blocks[i, j];
				if (blocks[i, j]!=0){
					GameObject instance=Instantiate(blockObjects[blocks[i, j]-1], new Vector2(j*.5f, i*.5f), Quaternion.identity) as GameObject;
					instance.transform.SetParent(worldHolder);
				}
			}
			world+="\n";
		}
		//GameObject instance2 = Instantiate (blockObjects [0], new Vector2 (5, 12), Quaternion.identity) as GameObject;
		//instance2.transform.SetParent (worldHolder);
		Debug.Log (world);
	}

	void generateBlocks(int x0, int y0){
		int x = radius;
		//int x = 20;
		int y = 0;
		int decisionOver2=1-x;

		while (y<=x){
			blocks[ x + x0, y + y0]=1;
			blocks[ y + x0, x + y0]=1;
			blocks[-x + x0, y + y0]=1;
			blocks[-y + x0, x + y0]=1;
			blocks[-x + x0, -y + y0]=1;
			blocks[-y + x0, -x + y0]=1;
			blocks[ x + x0, -y + y0]=1;
			blocks[ y + x0, -x + y0]=1;
			y++;
			if (decisionOver2<=0)
			{
				decisionOver2 += 2 * y + 1;   // Change in decision criterion for y -> y+1
			}
			else
			{
				x--;
				decisionOver2 += 2 * (y - x) + 1;   // Change for y -> y+1, x -> x-1
			}
		}

		for (int i=0; i<blocks.GetLength(0); i++) {
			bool toggle = false;
			int count=0;
			for (int j=0; j<blocks.GetLength(1); j++) {
				if (blocks[i, j]==1&&toggle==false){
					toggle=true;
					count++;
				}
				else if (blocks[i, j]==0&&toggle==true){
					toggle=false;
					count++;
				}
			}
			if (count==4){
				toggle=false;
				count=0;
				for (int j=0; j<blocks.GetLength(1); j++){
					if (blocks[i, j]==1&&toggle==false){
						toggle=true;
						count++;
					}
					else if (toggle==true && blocks[i, j]==0){
						toggle=false;
						count++;	
					}
					if (blocks[i,j]==0&&count==2)
						blocks[i,j]=1;
				}
			}

		}/*
		int distance = (blocks.GetLength (0) - radius * 2) / 2;
		for (int i=0; i<5; i++) {
			x=Random.Range(0, blocks.GetLength(0));
			y=Random.Range(0, blocks.GetLength(0));
			while (blocks[x, y]==0){
				x=Random.Range(0, blocks.GetLength(0));
				y=Random.Range(0, blocks.GetLength(0));
			}
			int count=5+Random.Range(-2, 2);
			int rand=Random.Range(1, 150);
			int index=0;
			for (; index<res.GetLength(0); index++){
				if (rand<=res[index])
					break;
			}
			while (count>0&&index!=res.GetLength(0)){
				if (blocks[x, y]==1){
					blocks[x, y]=i+2;
					count--;
				}
				int dir=Random.Range(0,3);
				if (dir==0 && blocks[x, y+1]==1) y++;
				else if (dir==1 && blocks[x, y-1]==1) y--;
				else if (dir==2 && blocks[x+1, y]==1) x++;
				else if (dir==3 && blocks[x-1, y]==1) x--;
			}
			if (Random.Range (1, 100) < 25)
				i--;
		}*/


	}

	void generateCaves(int i, int j){
		if (Random.Range (1, 100) <= 3) {
			generateCaves (Random.Range (5, blocks.GetLength (0) - 5), Random.Range (5, blocks.GetLength (1) - 5));
			//generateCaves(blocks.GetLength(0)/2, blocks.GetLength(1)/2);
		}
		if (ifSurrounded (i, j)) 
			return;
		int dir=Random.Range(0,3);
		while (blocks[i, j]==0){
			//dir=Random.Range(0,3);
			if (dir==0 && blocks[i, j+1]==1) j++;
			else if (dir==1 && blocks[i, j-1]==1) j--;
			else if (dir==2 && blocks[i+1, j]==1) i++;
			else if (dir==3 && blocks[i-1, j]==1) i--;
			dir++;
			dir=dir%4;
		}
		blocks [i, j] = 0;
		generateCaves (i, j);
	}

	void generateResources(){
		int distance = (blocks.GetLength (0) - radius * 2) / 2;
		for (int i=0; i<res.GetLength(0); i++) {
			int x=Random.Range(0, blocks.GetLength(0));
			int y=Random.Range(0, blocks.GetLength(0));
			while (blocks[x, y]==0){
				x=Random.Range(0, blocks.GetLength(0));
				y=Random.Range(0, blocks.GetLength(0));
			}
			int count=5;
			while (count>0){
				if (blocks[x, y]==1){
					blocks[x, y]=i+2;
					count--;
				}
				int dir=Random.Range(0,3);
				if (dir==0 && blocks[x, y+1]==1) y++;
				else if (dir==1 && blocks[x, y-1]==1) y--;
				else if (dir==2 && blocks[x+1, y]==1) x++;
				else if (dir==3 && blocks[x-1, y]==1) x--;
			}
		}
		for (int i=distance; i<blocks.GetLength(0)-distance; i++) {
			for (int j=distance; j<blocks.GetLength(1)-distance; j++) {
				/**/for (int k=0; k<res.GetLength(0); k++){
					if (Random.Range(1, 100)<=(res[k]+k)){
						int count=5;
						while (count>0){
							if (blocks[i, j]==1)
								blocks[i, j]=k+2;
							int dir=Random.Range(0,3);
							if (dir==0 && blocks[i, j+1]==1) j++;
							else if (dir==1 && blocks[i, j-1]==1) j--;
							else if (dir==2 && blocks[i+1, j]==1) i++;
							else if (dir==3 && blocks[i-1, j]==1) i--;
							count--;
							if (Random.Range(0, 100)<10)
								count++;
						}
					}
				}/**/
				/*
				int rand = Random.Range (1, 200);
				for (int k=0; k<res.GetLength(0); k++) {
					if (res [k] <= rand) {
						int count = 5;
						while (count>0) {
							if (blocks [i, j] == 1)
								blocks [i, j] = k + 2;
							int dir = Random.Range (0, 3);
							if (dir == 0 && blocks [i, j + 1] == 1)
								j++;
							else if (dir == 1 && blocks [i, j - 1] == 1)
								j--;
							else if (dir == 2 && blocks [i + 1, j] == 1)
								i++;
							else if (dir == 3 && blocks [i - 1, j] == 1)
								i--;
							count--;
							if (Random.Range (0, 100) < 10)
								count++;
						}
						break;
					}
				}*/
			}
		}
	}


	bool ifSurrounded(int i, int j){
		if (blocks [i, j-1] == 0
			&& blocks [i, j+1] == 0
			&& blocks [i+1, j] == 0
			&& blocks [i-1, j] == 0)
			return true;
		return false;
	}

	
}
