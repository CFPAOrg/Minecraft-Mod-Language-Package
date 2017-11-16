-- Author @3TUSK
-- This file is licensed under CC-BY-SA 4.0 International
-- See here for more details about license: 
-- https://creativecommons.org/licenses/by-sa/4.0/
-- ------------------------------------------------------------------------
-- User instruction:
-- 1.Put corresponding en_US.lang and zh_CN.lang into same folder
-- 2.Install lua 5.3.2
-- 3.Put this script where there are language files mentioned in 1.
-- 4.Execute "lua Tool_Update.lua"
-- 5.The result is "zh_CN-merged.lang"
-- -----------------------------------------------------------------------

local Entry = require("lib/entry")

function findExistedEntry(key, existMapping)
  for k, v in pairs(existMapping) do
    if key == nil then
      return key, false
    end
    if (v:getKey() == key:getKey()) then
      key:setValue(v:getValue())
      return key, true
    else
    end
  end

  return key, false
end

local enUSFile = io.open("en_US.lang")
local zhCNFile = io.open("zh_CN.lang")
local outputFinal = io.open("zh_CN-merged.lang", "w+")

local mapping = {}
local zhCN = {}

print("Language file update started, please stand by...")

count = 1

for s in enUSFile:lines() do
  if (string.match(s, ".*=.*")) then
    mapping[count] = Entry:parse(s)
  else
    mapping[count] = s
  end
  count = count + 1
end

print("Readed "..count.." lines in en_US.lang")

count = 1
for s in zhCNFile:lines() do
  if (string.match(s, ".*=.*")) then
    zhCN[count] = Entry:parse(s)
  end
  count = count + 1
end

print("Readed "..count.." lines in zh_CN.lang")

for i, v in ipairs(mapping) do
  if (type(v) == "string") then
    outputFinal:write(v.."\n")
  else 
    local translated = findExistedEntry(v, zhCN)
    outputFinal:write(tostring(translated).."\n")
  end 
end 

print("Language file successfully updated.")

outputFinal:flush()
outputFinal:close()
enUSFile:close()
zhCNFile:close()
