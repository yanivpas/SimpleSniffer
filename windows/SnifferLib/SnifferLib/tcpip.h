#include <stdint.h>
#ifndef TCPIP_HEADER
#define TCPIP_HEADER

#define MAC_ADDR_SIZE 6
#define ETHERNET_TYPE_IPV4 (0x800)

#define IP_PROTOCOL_TCP (0x6)
#define IPV4_ADDRESS_SIZE (0x4)

#define TCP_SYN_FLAG (0x02)
#define TCP_FIN_FLAG (0x01)

extern "C" {
#pragma pack(1)
	struct ethernet_header {
		uint8_t dst[MAC_ADDR_SIZE];
		uint8_t src[MAC_ADDR_SIZE];
		uint16_t type;
	};

#pragma pack(1)
	struct ipv4_header {
		uint8_t header_len : 4;
		uint8_t version : 4;
		uint8_t dsf;
		uint16_t total_len;
		uint16_t identification;
		uint8_t frag_offset1;
		uint8_t frag_offset2 : 5;
		uint8_t flags : 3;
		uint8_t ttl;
		uint8_t protocol;
		uint16_t checksum;
		uint8_t src[IPV4_ADDRESS_SIZE];
		uint8_t dst[IPV4_ADDRESS_SIZE];
	};

#pragma pack(1)
	struct tcp_header {
		uint16_t src_port;
		uint16_t dst_port;
		uint32_t seq;
		uint32_t ack;
		uint8_t header_len;
		uint8_t flags;
		uint16_t window_size;
		uint16_t checksum;
		uint16_t urgent_pointer;
	};
}
#endif
