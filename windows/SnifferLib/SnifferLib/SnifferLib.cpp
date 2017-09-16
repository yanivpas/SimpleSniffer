// SnifferLib.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "pcap.h"
#include "packet_parser.h"

#define TIMEOUT 1000



static pcap_t *g_pcap;
static pcap_if_t *g_pcap_if;
extern "C" {
#pragma pack(1)
	struct sniffer_data {
		struct connection conn;
		char pad1;
		char tcp_flags;
		char pad2;
		uint32_t data;
		char pad3;
		uint16_t len;
		char pad4;
		uint32_t original_data;
	};
	__declspec(dllexport) void sniffer_init(void)
	{
		char errbuf[PCAP_ERRBUF_SIZE];
		int ret_value = -1;
		ret_value = pcap_findalldevs(&g_pcap_if, errbuf);
		if (-1 == ret_value) {
			printf("%s\n", errbuf);
			return;
		}
		g_pcap = pcap_open_live(g_pcap_if->name, 1000, 0, TIMEOUT, errbuf);
		if (NULL == g_pcap) {
			printf("%s\n", errbuf);
			return;
		}
		return;

	}

	__declspec(dllexport) int sniffer_get(struct sniffer_data *ret_data)
	{

		char *data;
		char tcp_flags;
		char *bytes;
		int ret_value;
		struct pcap_pkthdr h = {0};
		bytes = (char*)pcap_next(g_pcap, &h);
		if (bytes != NULL) {
			ret_value = (int)get_tcp_data((char*)bytes, h.len, &(ret_data->conn), &tcp_flags, &data);
			ret_data->tcp_flags = tcp_flags;
			ret_data->data = (uint32_t)data;
			ret_data->len = bytes + h.len - data;
			ret_data->original_data = (uint32_t)bytes;
			ret_data->pad1 = 0xaa;
			ret_data->pad2 = 0xbb;
			ret_data->pad3 = 0xcc;
			ret_data->pad4 = 0xdd;
			return ret_value;
		}
		else {
			return PPARSER_INTERNAL_ERROR;
		}
	}
	__declspec(dllexport) int sniffer_get_inteface(char **interface_name) {
		if (g_pcap_if != NULL) {
			*interface_name = g_pcap_if->name;
			g_pcap_if = g_pcap_if->next;

		}
		else {
			*interface_name = NULL;
		}
		return 0;
	}
	__declspec(dllexport) int sniffer_set_inteface(char *if_name) {
		char errbuf[PCAP_ERRBUF_SIZE];
		int ret_value = -1;
		g_pcap = pcap_open_live(if_name, 1000, 0, TIMEOUT, errbuf);
		return (int)g_pcap;
	}
}