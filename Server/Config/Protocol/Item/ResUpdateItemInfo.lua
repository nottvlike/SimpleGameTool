-- automatically generated by the FlatBuffers compiler, do not modify

-- namespace: Item

local flatbuffers = require('flatbuffers')

local ResUpdateItemInfo = {} -- the module
local ResUpdateItemInfo_mt = {} -- the class metatable

function ResUpdateItemInfo.New()
    local o = {}
    setmetatable(o, {__index = ResUpdateItemInfo_mt})
    return o
end
function ResUpdateItemInfo.GetRootAsResUpdateItemInfo(buf, offset)
    local n = flatbuffers.N.UOffsetT:Unpack(buf, offset)
    local o = ResUpdateItemInfo.New()
    o:Init(buf, n + offset)
    return o
end
function ResUpdateItemInfo_mt:Init(buf, pos)
    self.view = flatbuffers.view.New(buf, pos)
end
function ResUpdateItemInfo_mt:ItemInfo()
    local o = self.view:Offset(4)
    if o ~= 0 then
        local x = self.view:Indirect(o + self.view.pos)
        local obj = require('Protocol.Item.ItemInfo').New()
        obj:Init(self.view.bytes, x)
        return obj
    end
end
function ResUpdateItemInfo.Start(builder) builder:StartObject(1) end
function ResUpdateItemInfo.AddItemInfo(builder, itemInfo) builder:PrependUOffsetTRelativeSlot(0, itemInfo, 0) end
function ResUpdateItemInfo.End(builder) return builder:EndObject() end

return ResUpdateItemInfo -- return the module