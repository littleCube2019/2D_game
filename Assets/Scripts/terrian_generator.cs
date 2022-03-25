using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrian_generator : MonoBehaviour
{
    // Start is called before the first frame update
    public int world_size = 30;
    public BlockCollection Dirts;
    int view_distance = 9  ; 
    int transport_buffer_distance = 2;
  

    List<Vector2> allBlockPos = new List<Vector2>();
    List<GameObject> allBlock = new List<GameObject>();
    void Start()
    {
        TerrianGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int  inTheCloneZone(int x){
        if( 0 <= x && x< 2*view_distance+transport_buffer_distance ){
                return -1;
        }
        if(x>= world_size){
                return 1;
        }
        return 0;
    }
    public void playerDestroyBlock(int x , int y){
        if(allBlockPos.Contains(new Vector2(x,y))){
                
                int index = allBlockPos.IndexOf(new Vector2(x,y));
                Destroy(allBlock[index]);
                allBlock.RemoveAt(index);
                allBlockPos.RemoveAt(index);


                if( inTheCloneZone(x) == -1){ //back
                    int otherIndex = allBlockPos.IndexOf(new Vector2(x+world_size,y));
                    Destroy(allBlock[otherIndex]);
                    allBlock.RemoveAt(otherIndex);
                    allBlockPos.RemoveAt(otherIndex);
                }
                else if( inTheCloneZone(x) == 1){ //front
                    int otherIndex = allBlockPos.IndexOf(new Vector2(x-world_size,y));
                    Destroy(allBlock[otherIndex]);
                    allBlock.RemoveAt(otherIndex);
                    allBlockPos.RemoveAt(otherIndex);
                }
        }

       
    }



    public void playerConstructBlock(Block block ,int x , int y){
        Debug.Log(new Vector2(x,y));
        if(!allBlockPos.Contains(new Vector2(x,y))){
                
                int index = allBlockPos.IndexOf(new Vector2(x,y));
                Vector2 newPos = new Vector2(x,y);
                placeBlock(block , newPos , true);


                if( inTheCloneZone(x) == -1){ //back
                    Vector2 otherNewPos = new Vector2(x+world_size,y);
                    placeBlock(block , otherNewPos , true);
                   
                }
                else if( inTheCloneZone(x) == 1){ //front
                    Vector2 otherNewPos = new Vector2(x-world_size,y);
                    placeBlock(block , otherNewPos , true);
                }
        }

       
    }
    public  void TerrianGenerator(){
        int counter = 0;
        int total = 2 * view_distance + transport_buffer_distance +  world_size;
        for(int x = 0 ; x < total ; x++){
            Vector2 newPos = new Vector2(x,0);
            Block newBlock =  Dirts.whitedirt;
            if( x < view_distance ){
               newBlock =Dirts.reddirt;

            }   
            else if( x < view_distance+transport_buffer_distance ){
                newBlock =Dirts.bluedirt;
            }
            else if( x < 2*view_distance+transport_buffer_distance ){
                 newBlock =Dirts.reddirt;
            }
            else if (x < world_size ){
                   newBlock =Dirts.blackdirt;
            }

            else if (x< world_size+view_distance  ){
                    newBlock =Dirts.reddirt;
            }
            else if (x< world_size+view_distance+transport_buffer_distance  ){
                    newBlock =Dirts.bluedirt;
            }

            else if (x< world_size+view_distance*2+transport_buffer_distance ){
                      newBlock =Dirts.reddirt;
            }
            placeBlock(newBlock , newPos , true);
            counter ++;
        }

    }

    public void placeBlock(Block block , Vector2 pos , bool isFrontGround){
        GameObject newCube = new GameObject();
        newCube.AddComponent<SpriteRenderer>();
        newCube.GetComponent<SpriteRenderer>().sprite = block.blockSprite;
        newCube.transform.position =  pos;

        if(isFrontGround){
            newCube.AddComponent<BoxCollider2D>();

        }
        newCube.layer = 3;
        // record block and position align , so we can use position to find block later. 
        allBlockPos.Add(pos);
        allBlock.Add(newCube);
    }
}
