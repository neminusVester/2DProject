using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLevel 
{

    public List<BlockObject> GetBlocks()
    {
        List<BlockObject> objects = new List<BlockObject>();
        GameObject[] allBlocks = GameObject.FindGameObjectsWithTag("block");

        foreach (var item in allBlocks)
        {
            BlockObject blockObject = new BlockObject();
            blockObject.Position = item.gameObject.transform.position;

            if (item.TryGetComponent(out Block block))
            {
                blockObject.Block = block.BlockData;
            }

            if (item.TryGetComponent(out OtherBlock otherBlock))
            {
                blockObject.Block = otherBlock.BlockData;
            }
            objects.Add(blockObject);
        }
        return objects;
    }
}
