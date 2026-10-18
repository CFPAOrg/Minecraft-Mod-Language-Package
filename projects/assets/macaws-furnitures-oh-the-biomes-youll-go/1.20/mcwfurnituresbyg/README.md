### 总概

```mermaid
flowchart LR
    1.20.1 -->|indirect| 1.20.1-fabric
    1.20.1 -->|indirect| 1.19.2/1.19.2-fabric -->|indirect| 1.18.2 -->|indirect| 1.16.5
    1.19.2/1.19.2-fabric -->|composition| 1.18.2 -->|composition| 1.16.5
    linkStyle 4,5 color:royalblue,stroke:royalblue
```

```
1.20.1
 ├── 1.20.1-fabric
 └── 1.19.2 (composition)
      └── 1.18.2 (composition)
           └── 1.16.5
```

### 链接区域

- [1.16.5](/projects/assets/macaws-furnitures-oh-the-biomes-youll-go/1.16/mcwfurnituresbyg)
- [1.18.2](/projects/assets/macaws-furnitures-oh-the-biomes-youll-go/1.18/mcwfurnituresbyg)
- [1.19.2](/projects/assets/macaws-furnitures-oh-the-biomes-youll-go/1.19/mcwfurnituresbyg)
- [1.20.1](/projects/assets/macaws-furnitures-oh-the-biomes-youll-go/1.20/mcwfurnituresbyg)
- [1.19.2-fabric](/projects/assets/macaws-furnitures-oh-the-biomes-youll-go/1.19/mcwfurnituresbyg)
- [1.20.1-fabric](/projects/assets/macaws-furnitures-oh-the-biomes-youll-go/1.20-fabric/mcwfurnituresbyg)