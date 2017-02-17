﻿using System.Collections;

    /**
     * <summary>Flag that determines if this layer should loop horizontally</summary>
     * */
    public bool loopHorizontal;
    /**
     * <summary>Flag that determines if this layer should loop vertically</summary>
     * */
    public bool loopVertical;
        get {
            return _hDistanceBetweenBgs;
        }
    }
        get {
            return _vDistanceBetweenBgs;
        }
    }
            _hDistanceBetweenBgs = 0;
            _vDistanceBetweenBgs = 0;
        }
            SpriteRenderer objRender = gameObject.GetComponent<SpriteRenderer>();
            _hDistanceBetweenBgs = 2 * (1f / gameObject.transform.parent.localScale.x) * (objRender.bounds.max.x - transform.position.x);
            Debug.Log(objRender.bounds.max.x);
            _vDistanceBetweenBgs = 2 * (1f / gameObject.transform.parent.localScale.y) * (objRender.bounds.max.y - transform.position.y);
        transform.localPosition = transform.localPosition + new Vector3(_hDistanceBetweenBgs, 0);
    }
        transform.localPosition = transform.localPosition - new Vector3(_hDistanceBetweenBgs, 0);
    }
        transform.localPosition = transform.localPosition + new Vector3(0, _vDistanceBetweenBgs);
    }
    
    public void MoveDown() {
        transform.localPosition = transform.localPosition - new Vector3(0, _vDistanceBetweenBgs);
    }
    /// Create a new Sub Layer.
    /// </summary>
    /// <returns></returns>
        // In order to create an layer loop, I will need a new Game Object that will inherit almost
        // all of my properties, except for Background Layer Component, since only me needs it in
        // order to work.

        SpriteRenderer objRender = gameObject.GetComponent<SpriteRenderer>();

        GameObject subLayer = new GameObject("SubLayer" + transform.childCount);
        subLayer.transform.SetParent(transform);
        SpriteRenderer render = subLayer.AddComponent<SpriteRenderer>();
        render.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        render.sortingLayerName = objRender.sortingLayerName;
        render.sortingOrder = objRender.sortingOrder;

        subLayer.transform.localScale = Vector3.one;
        return subLayer;
    }
        // If I was setted to loop horizontally, create a new sublayer (loop) to the right of the origin point.
        if(loopHorizontal) {
            CreateLayerLoop().transform.localPosition = new Vector2(_hDistanceBetweenBgs, 0);
        }

        // If I was setted to loop vertically, create a new sublayer (loop) up of the origin point.
        if(loopVertical) {
            CreateLayerLoop().transform.localPosition = new Vector2(0, _vDistanceBetweenBgs);
            // If setted to loop both ways, create an extra layer to fill diagonally
            if(loopHorizontal) {
                CreateLayerLoop().transform.localPosition = new Vector2(_hDistanceBetweenBgs, _vDistanceBetweenBgs);
            }
        }
    }