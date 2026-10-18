### 总概

```mermaid
flowchart LR
    1.21.1 -->|indirect| 1.21.1-fabric
    1.20.1 -->|indirect| 1.20.1-fabric
    1.19.2/1.19.2-fabric
    1.18.2 -->|indirect| 1.18.2-fabric[1.18.2-fabric<br/>singleton]
    1.21.1 -->|indirect| 1.20.1 & 1.19.2/1.19.2-fabric & 1.18.2 & 1.16.5
```

```
1.21.1
 ├── 1.21.1-fabric
 ├── 1.20.1
 │    └── 1.20.1-fabric
 ├── 1.19.2/1.19.2-fabric
 ├── 1.18.2
 │    └── 1.18.2-fabric (singleton)
 └── 1.16.5
```

### 链接区域

- [1.16.5](/projects/assets/macaws-trapdoors/1.16/mcwtrpdoors)
- [1.18.2](/projects/assets/macaws-trapdoors/1.18/mcwtrpdoors)
- [1.19.2](/projects/assets/macaws-trapdoors/1.19/mcwtrpdoors)
- [1.20.1](/projects/assets/macaws-trapdoors/1.20/mcwtrpdoors)
- [1.21.1](/projects/assets/macaws-trapdoors/1.21/mcwtrpdoors)
- [1.18.2-fabric](/projects/assets/macaws-trapdoors/1.18-fabric/mcwtrpdoors)
- [1.20.1-fabric](/projects/assets/macaws-trapdoors/1.20-fabric/mcwtrpdoors)
- [1.21.1-fabric](/projects/assets/macaws-trapdoors/1.21-fabric/mcwtrpdoors)